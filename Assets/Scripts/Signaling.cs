using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private Transform _rogue;
    [SerializeField] private int _duration;

    private AudioSource _signal;
    private float _elapsedTime;
    private int _target;

    private void Start()
    {
        _signal = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_signal.enabled == true)
        {
            ControlSound(_target);
        }

        if (_signal.volume == 0)
        {
            _signal.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _signal.enabled = true;
            _target = 1;
            _elapsedTime = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _target = 0;
            _elapsedTime = 0;
        }
    }

    private void ControlSound(int target)
    {
        _elapsedTime += Time.deltaTime;
        _signal.volume = Mathf.MoveTowards(_signal.volume, target, _elapsedTime / _duration);
    }
}