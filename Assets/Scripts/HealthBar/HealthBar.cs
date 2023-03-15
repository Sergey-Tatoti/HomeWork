using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class HealthBar : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void IncreaseHealth()
    {
        _health.Increase();
    }

    public void ReduceHealth()
    {
        _health.Reduce();
    }
}
