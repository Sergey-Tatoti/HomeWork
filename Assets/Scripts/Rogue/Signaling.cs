using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private int _duration;
    [SerializeField] private SignalingTrigger _signalingTrigger;

    private AudioSource _signal;

    private void Start()
    {
        _signal = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _signalingTrigger.RougeCameIn += UseSound;
    }

    private void OnDisable()
    {
        _signalingTrigger.RougeCameIn -= UseSound;
    }

    private void UseSound(int target)
    {
        _signal.enabled = true;
        
        StartCoroutine(ChangeSound(target));

        if (_signal.volume == 0)
        {
            _signal.enabled = false;
        }
    }

    private IEnumerator ChangeSound(int target)
    {
        float elapsedTime = 0;

        while (_signal.volume != target)
        {
            elapsedTime += Time.deltaTime;
            _signal.volume = Mathf.MoveTowards(_signal.volume, target, elapsedTime / _duration);

            yield return null;
        }
    }
}