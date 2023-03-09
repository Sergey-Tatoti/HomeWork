using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class JumpMan : MonoBehaviour
{
    private const string Jump = "Jump";

    [SerializeField] private int _jumpForce;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool _isJump;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Leap()
    {
        _animator.SetBool(Jump, false);

        if (Input.GetKey(KeyCode.Space))
        {
            if (_isJump == true)
            {
                _rigidbody2D.AddForce(Vector2.up * _jumpForce);
                _animator.SetBool(Jump, true);
                _isJump = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _isJump = true;
    }
}
