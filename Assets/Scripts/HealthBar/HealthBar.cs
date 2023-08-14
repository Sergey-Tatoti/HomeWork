using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Health
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration;

    private float _tempSliderValue;

    private void Awake()
    {
        _slider.value = _startHealth;
        _tempSliderValue = _slider.value;
    }

    private void OnEnable() 
    {
        _health.MoveSlider += OnChange;
    }
    private void OnDisable() 
    {
        _health.MoveSlider -= OnChange;
    }

    private void OnChange(int health)
    {
        _tempSliderValue += health;

        StartCoroutine(Draw());
    }

    private IEnumerator Draw()
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
