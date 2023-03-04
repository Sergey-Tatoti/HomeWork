using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemProtect : MonoBehaviour
{
    private Signaling _signaling;
    private int _target;
    private int _timeOffSignal = 2;

    private void Start()
    {
        _signaling = GetComponent<Signaling>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _signaling.enabled = true;
            _signaling.ControlSound(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            Invoke("OffSignal", _timeOffSignal);
            _signaling.ControlSound(false);
        }
    }

    private void OffSignal()
    {
        _signaling.enabled = false;
    }
}
