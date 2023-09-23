using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Health
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration;

    private void Awake()
    {
        _slider.value = _startHealth;
    }

    private void OnEnable() 
    {
        _health.MoveHealth += OnMoveHealth;
    }

    private void OnDisable() 
    {
        _health.MoveHealth -= OnMoveHealth;
    }

    private void OnMoveHealth(int health)
    {
        StartCoroutine(Draw(health));
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
    }
}