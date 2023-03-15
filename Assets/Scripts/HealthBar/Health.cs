using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration;

    private int _health = 20;
    private float _tempSliderValue;

    private void Awake()
    {
        _tempSliderValue = _slider.value;
    }

    public void Increase()
    {
        Change(_slider.maxValue, _tempSliderValue, _health);
    }

    public void Reduce()
    {
        Change(_tempSliderValue, _slider.minValue, -_health);
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
