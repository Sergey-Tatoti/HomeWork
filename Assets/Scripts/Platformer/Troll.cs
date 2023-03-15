using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrollMovement))]

public class Troll : MonoBehaviour
{
    private TrollMovement _movementTroll;

    private void Awake()
    {
        _movementTroll = GetComponent<TrollMovement>();
    }

    private void Update()
    {
        _movementTroll.Move();
    }
}
