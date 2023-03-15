using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInstantiate : MonoBehaviour
{
    [SerializeField] private Zombie _zombie;
    [SerializeField] private Transform[] _flagsRespawn;

    private WaitForSeconds _timeCreateZombie;
    private int TimeCreated = 2;

    private void Start()
    {
        _timeCreateZombie = new WaitForSeconds(TimeCreated);
        
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        for (int i = 0; i < _flagsRespawn.Length; i++)
        {
            Instantiate(_zombie, new Vector2(_flagsRespawn[i].position.x, _flagsRespawn[i].position.y), Quaternion.identity);

            yield return _timeCreateZombie;
        }
    }
}