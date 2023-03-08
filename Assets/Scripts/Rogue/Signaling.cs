using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private int _duration;

    private AudioSource _signal;
    private float _elapsedTime;
    private int _target;
    private int _maxVolume = 1;
    private void Start()
    {
        _signal = GetComponent<AudioSource>();
    }

    public void ControlSound(bool isDanger)
    {
        _elapsedTime = 0;

        if (isDanger == true)
        {
            _signal.enabled = true;
            _target = _maxVolume;
        }
        else
        {
            _target = 0;
        }

        StartCoroutine(UseSound());
    }

    private IEnumerator UseSound()
    {
        while (_signal.volume != _target)
        {
            _elapsedTime += Time.deltaTime;
            _signal.volume = Mathf.MoveTowards(_signal.volume, _target, _elapsedTime / _duration);

            yield return null;
        }

        if(_signal.volume == 0)
        {
            _signal.enabled = false;
        }
    }
}