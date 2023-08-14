using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private int _damageHealth = 20;
    private int _maxHealth = 100;

    public UnityAction <int> MoveSlider;
    public int _startHealth {get; private set;} = 40;

    private void Increase()
    {
        if (_startHealth < _maxHealth)
        {
            _startHealth += _damageHealth;

            MoveSlider?.Invoke(_damageHealth);
        }
    }

    private void Reduce()
    {
        if (_startHealth > 0)
        {
            _startHealth -= _damageHealth;

            MoveSlider?.Invoke(-_damageHealth);
        }
    }
}
