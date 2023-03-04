using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerZombie : MonoBehaviour
{
    [SerializeField] private int _speed;
    
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
