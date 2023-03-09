using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private int _duration;

    private AudioSource _signal;

    private void Start()
    {
        _signal = GetComponent<AudioSource>();
    }

    public IEnumerator UseSound(int target)
    {
        float elapsedTime = 0;

        _signal.enabled = true;

        while (_signal.volume != target)
        {
            elapsedTime += Time.deltaTime;
            _signal.volume = Mathf.MoveTowards(_signal.volume, target, elapsedTime / _duration);

            yield return null;
        }

        if(_signal.volume == 0)
        {
            _signal.enabled = false;
        }
    }
}