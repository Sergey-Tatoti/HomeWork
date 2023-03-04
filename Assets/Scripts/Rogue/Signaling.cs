using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private int _duration;

    private AudioSource _signal;
    private float _elapsedTime;
    private int _target;
    private int _maxVolume = 1;

    public void ControlSound(bool isDanger)
    {
        _elapsedTime = 0;

        if (isDanger == true)
        {
            _target = _maxVolume;
        }
        else
        {
            _target = 0;
        }
    }

    private void Start()
    {
        _signal = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        _signal.volume = Mathf.MoveTowards(_signal.volume, _target, _elapsedTime / _duration);
    }
}