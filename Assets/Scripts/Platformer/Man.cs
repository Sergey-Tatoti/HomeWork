using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ManMovement))]
[RequireComponent(typeof(ManJump))]

public class Man : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Animator _animator;
    private ManMovement _moveController;
    private ManJump _jumpController;
    private Rigidbody2D _rigidbody2D;

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
        var Scene = _camera.GetComponent<Scene>();

        if (other.TryGetComponent<Troll>(out Troll troll))
        {
            Scene.Reload();
        }
    }
}
