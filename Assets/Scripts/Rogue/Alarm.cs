using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Signaling))]

public class Alarm : MonoBehaviour
{
    private Signaling _signaling;

    private void Start()
    {
        _signaling = GetComponent<Signaling>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _signaling.ControlSound(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _signaling.ControlSound(false);
        }
    }
}
