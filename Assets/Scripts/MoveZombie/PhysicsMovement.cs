using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    private const float MinMoveDistance = 0.001f;
    private const float ShellRadius = 0.01f;

    [SerializeField] private Vector2 _velocity;
    [SerializeField] private LayerMask _layerMask;

    private Vector2 _targetVelocity;
    private Vector2 _groundNormal;
    private ContactFilter2D _contactFilter2D;
    private RaycastHit2D[] _hitBuffers = new RaycastHit2D[16];
    private List<RaycastHit2D> _hitBufferList = new List<RaycastHit2D>(16);
    private Rigidbody2D _rigidbody2D;
    private float _gravityModifier = 1f;
    private float _minGroundNormalY = 0.65f;
    private bool _isGrounded;

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _contactFilter2D.useTriggers = false;
        _contactFilter2D.SetLayerMask(_layerMask);
        _contactFilter2D.useLayerMask = true;
    }
    private void Update()
    {
        _targetVelocity = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _velocity.y = 5;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("Это общая скорость" + _velocity + "Это скорость по х" + _velocity.x);
        _velocity += _gravityModifier * Physics2D.gravity * Time.deltaTime;
        _velocity.x = _targetVelocity.x;

        _isGrounded = false;

        Vector2 deltaPosition = _velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(_groundNormal.y, -_groundNormal.x); //почему местами поменяли?
        Vector2 move = moveAlongGround * deltaPosition.x;

        Debug.Log("Это расстояние" + deltaPosition + "Это движение вдоль земли" + moveAlongGround);
        Debug.Log("Движение" + move);

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    private void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;
        Debug.Log("Длина дистанции перемещения - " + distance);

        if (distance > MinMoveDistance)
        {
            int count = _rigidbody2D.Cast(move, _contactFilter2D, _hitBuffers, distance + ShellRadius);

            _hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                _hitBufferList.Add(_hitBuffers[i]);
            }

            for (int i = 0; i < _hitBufferList.Count; i++)
            {
                Vector2 currentNormal = _hitBufferList[i].normal;

                if (currentNormal.y > _minGroundNormalY)
                {
                    _isGrounded = true;

                    if (yMovement)
                    {
                        _groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(_velocity, currentNormal);

                if (projection < 0)
                {
                    _velocity = _velocity - projection * currentNormal;
                }

                float modifiedDistance = _hitBufferList[i].distance - ShellRadius;

                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        _rigidbody2D.position = _rigidbody2D.position + move.normalized * distance;
    }

}
