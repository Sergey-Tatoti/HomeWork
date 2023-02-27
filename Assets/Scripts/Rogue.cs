using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private Transform _finishPoint;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

        if(_finishPoint.position.x <= transform.position.x)
        {
        _spriteRenderer.flipX = true;
        _speed = -_speed;
        }
    }
}
