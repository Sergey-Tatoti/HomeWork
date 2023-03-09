using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class MovementMan : MonoBehaviour
{
    private const string Speed = "Speed";
    private const int Idle = 0;
    private const int Run = 2;

    [SerializeField] private int _speed;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move()
    {
        _animator.SetFloat(Speed, Idle);

        if (Input.GetKey(KeyCode.D))
            DirectMove(false, _speed);

        if (Input.GetKey(KeyCode.A))
            DirectMove(true, -_speed);
    }

    private void DirectMove(bool isLeft, int speed)
    {
        _spriteRenderer.flipX = isLeft;
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        _animator.SetFloat(Speed, Run);
    }
}
