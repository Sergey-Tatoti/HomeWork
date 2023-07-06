using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;
    [SerializeField] private float _duration;

    private float _tempSliderValue;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _tempSliderValue = _slider.value;
    }

    private void OnEnable()
    {
        _health.IncreaseHealth += IncreaseHealth;
        _health.ReduceHealth += ReduceHealth;
    }

    private void OnDisable()
    {
        _health.IncreaseHealth -= IncreaseHealth;
        _health.ReduceHealth -= ReduceHealth;
    }

    private void IncreaseHealth(int health)
    {
        Change(_slider.maxValue, _tempSliderValue, health);
    }

    private void ReduceHealth(int health)
    {
        Change(_tempSliderValue, _slider.minValue, health);
    }

    private void Change(float greaterValueHealth, float lowerValueHealth, int health)
    {
        if (_tempSliderValue == _slider.value)
        {
            if (greaterValueHealth > lowerValueHealth)
            {
                _tempSliderValue += health;
                StartCoroutine(Drow());
            }
        }
    }

    private IEnumerator Drow()
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
