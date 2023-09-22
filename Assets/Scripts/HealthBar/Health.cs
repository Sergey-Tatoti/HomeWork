using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private int _damage = 10;
    private int _maxHealth = 100;

    public UnityAction <int> MoveHealth;
    public int _startHealth {get; private set;} = 40;

    private void Increase()
    {
        if (_startHealth < _maxHealth)
        {
            _startHealth += _damage;

            MoveHealth?.Invoke(_damage);
        }
    }

    private void Reduce()
    {
        if (_startHealth > 0)
        {
            _startHealth -= _damage;

            MoveHealth?.Invoke(-_damage);
        }
    }
}