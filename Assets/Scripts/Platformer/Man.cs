using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(JumpController))]

public class Man : MonoBehaviour
{
    [SerializeField] private GameObject _camera;

    private Animator _animator;
    private MoveController _moveController;
    private JumpController _jumpController;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _moveController = GetComponent<MoveController>();
        _jumpController = GetComponent<JumpController>();
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
