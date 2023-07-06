using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ManMovement))]
[RequireComponent(typeof(ManJump))]

public class Man : MonoBehaviour
{
    private Animator _animator;
    private ManMovement _moveController;
    private ManJump _jumpController;
    private Rigidbody2D _rigidbody2D;

    public UnityAction DeathMan;

    private void Awake()
    {
        _moveController = GetComponent<ManMovement>();
        _jumpController = GetComponent<ManJump>();
    }

    private void Update()
    {
        _moveController.Move();
        _jumpController.Leap();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<TrollMovement>(out TrollMovement troll))
        {
            DeathMan?.Invoke();
        }
    }
}
