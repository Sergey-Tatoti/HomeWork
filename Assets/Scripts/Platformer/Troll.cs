using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private Transform _leftFlag;
    [SerializeField] private Transform _rightFlag;

    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

        ChangeDirection();
    }

    private void ChangeDirection()
    {
        if (transform.position.x <= _leftFlag.position.x)
        {
            _spriteRenderer.flipX = false;
            _speed = -_speed;
        }

        if (transform.position.x >= _rightFlag.position.x)
        {
            _spriteRenderer.flipX = true;
            _speed = -_speed;
        }
    }
}
