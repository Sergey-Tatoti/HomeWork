using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Health
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration;

    private bool _canDrow = true;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        if (_canDrow == true)
        {
            StartCoroutine(Draw(health));
            _canDrow = false;
        }
    }

    private IEnumerator Draw(int health)
    {
        float elapsedTime = 0;

        while (health != _slider.value)
        {
            elapsedTime += Time.deltaTime;
            _slider.value = Mathf.MoveTowards(_slider.value, health, elapsedTime / _duration);

            yield return null;
        }

        _canDrow = true;
    }
}