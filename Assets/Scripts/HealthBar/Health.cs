using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private HealthBar _healthBar;
    private int _damageHealth = 20;
    private int _maxHealth = 100;
    private int _health = 40;

    private void Awake()
    {
        _healthBar = GetComponent<HealthBar>();
    }

    public int CostumizeHealthSlider()
    {
      return _health;
    }

    private void Increase()
    {
        if (_health < _maxHealth)
        {
            _health += _damageHealth;

            _healthBar.Change(_damageHealth);
        }
    }

    private void Reduce()
    {
        if (_health > 0)
        {
            _health -= _damageHealth;

            _healthBar.Change(-_damageHealth);
        }
    }
}
