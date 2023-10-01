using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private int _damage = 10;
    private int _maxHealth = 100;
    private int _currentHealth = 40;

    public UnityAction<int> HealthChanged;

    private void Start() 
    {
        HealthChanged?.Invoke(_currentHealth);
    }

    private void Increase()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += _damage;

            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;

            HealthChanged?.Invoke(_currentHealth);
        }
    }

    private void Reduce()
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= _damage;

            if (_currentHealth < 0)
                _currentHealth = 0;

            HealthChanged?.Invoke(_currentHealth);
        }
    }
}