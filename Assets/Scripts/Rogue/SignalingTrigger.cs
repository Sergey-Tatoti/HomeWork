using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalingTrigger : MonoBehaviour
{
    private int _maxVolume = 1;
    
    public UnityAction <int> UseSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            UseSound?.Invoke(_maxVolume);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            UseSound?.Invoke(0);
        }
    }
}
