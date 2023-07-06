using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalingTrigger : MonoBehaviour
{
    private int _maxVolume = 1;
    
    public UnityAction <int> UseSignalig;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            UseSignalig?.Invoke(_maxVolume);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            UseSignalig?.Invoke(0);
        }
    }
}
