using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZoombie : MonoBehaviour
{
    [SerializeField] private Zoombie _zoombie;
    [SerializeField] private Transform[] _flagsRespawn;

    private int TimeCreated = 2;

    private void Start()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        for (int i = 0; i < _flagsRespawn.Length; i++)
        {
            Instantiate(_zoombie, new Vector2(_flagsRespawn[i].position.x, _flagsRespawn[i].position.y), Quaternion.identity);

            yield return new WaitForSeconds(TimeCreated);
        }
    }
}
