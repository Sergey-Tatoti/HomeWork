using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration;
    
    private int _health = 20;
    private float _tempSliderValue;

    private void Awake()
    {
        _tempSliderValue = _slider.value;
    }

    public void HealthUp()
    {
        if (_tempSliderValue == _slider.value && _tempSliderValue < _slider.maxValue)
        {
            _tempSliderValue += _health;
            StartCoroutine(ChangeHealth());
        }
    }

    public void HealthDown()
    {
        if (_tempSliderValue == _slider.value && _tempSliderValue > _slider.minValue)
        {
            _tempSliderValue -= _health;
            StartCoroutine(ChangeHealth());
        }
    }

    private IEnumerator ChangeHealth()
    {
        float elapsedTime = 0;

        while (_tempSliderValue != _slider.value)
        {
            elapsedTime += Time.deltaTime;
            _slider.value = Mathf.MoveTowards(_slider.value, _tempSliderValue, elapsedTime / _duration);

            yield return null;
        }
    }
}
