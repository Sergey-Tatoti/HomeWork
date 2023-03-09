using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementMan))]
[RequireComponent(typeof(JumpMan))]

public class Man : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Animator _animator;
    private MovementMan _moveController;
    private JumpMan _jumpController;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _moveController = GetComponent<MovementMan>();
        _jumpController = GetComponent<JumpMan>();
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
