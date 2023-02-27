using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Man : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _jumpForce;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private int _countJump;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveController();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _countJump = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Troll>(out Troll troll))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void MoveController()
    {
        _animator.SetFloat("Speed", 0);

        if (Input.GetKey(KeyCode.D))
            DirectMove(false, _speed);

        if (Input.GetKey(KeyCode.A))
            DirectMove(true, -_speed);
    }

    private void DirectMove(bool isLeft, int speed)
    {
        _spriteRenderer.flipX = isLeft;
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        _animator.SetFloat("Speed", 2);
    }

    private void Jump()
    {
        _animator.SetBool("Jump", false);

        if (Input.GetKey(KeyCode.Space))
        {
            if (_countJump > 0)
            {
                _rigidbody2D.AddForce(Vector2.up * _jumpForce);
                _animator.SetBool("Jump", true);
                _countJump--;
            }
        }
    }
}
