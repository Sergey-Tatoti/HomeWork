using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Signaling))]

public class Alarm : MonoBehaviour
{
    private Signaling _signaling;
    private int _maxVolume = 1;

    private void Start()
    {
        _signaling = GetComponent<Signaling>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            StartCoroutine(_signaling.UseSound(_maxVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            StartCoroutine(_signaling.UseSound(0));
        }
    }
}
