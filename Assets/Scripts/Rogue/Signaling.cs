using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private int _duration;

    private AudioSource _signal;
    private float _elapsedTime;

    private void Start()
    {
        _signal = GetComponent<AudioSource>();
    }

    public IEnumerator UseSound(int target)
    {
        _signal.enabled = true;
        _elapsedTime = 0;

        while (_signal.volume != target)
        {
            _elapsedTime += Time.deltaTime;
            _signal.volume = Mathf.MoveTowards(_signal.volume, target, _elapsedTime / _duration);

            yield return null;
        }

        if(_signal.volume == 0)
        {
            _signal.enabled = false;
        }
    }
}