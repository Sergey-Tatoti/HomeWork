using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent<Man>(out Man rogue))
        {
            Destroy(this.gameObject);
        }
    }
}
