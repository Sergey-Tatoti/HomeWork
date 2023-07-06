using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private int _health = 20;

    public UnityAction<int> IncreaseHealth;
    public UnityAction<int> ReduceHealth;

    public void Increase()
    {
        IncreaseHealth?.Invoke(_health);
    }

    public void Reduce()
    {
        ReduceHealth?.Invoke(-_health);
    }
}
