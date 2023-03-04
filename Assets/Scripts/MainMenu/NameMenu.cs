using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NameMenu : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] int _speed;

    private void Update()
    {
        transform.DOMove(new Vector3(_target.position.x, _target.position.y, _target.position.z), _speed);
    }
}
