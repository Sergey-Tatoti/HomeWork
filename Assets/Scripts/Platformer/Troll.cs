using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementTroll))]

public class Troll : MonoBehaviour
{
    private MovementTroll _movementTroll;

    private void Awake()
    {
        _movementTroll = GetComponent<MovementTroll>();
    }

    private void Update()
    {
        _movementTroll.Move();
    }
}
