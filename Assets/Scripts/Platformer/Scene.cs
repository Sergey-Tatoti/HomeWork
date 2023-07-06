using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField] private Man _man;

    private void OnEnable() 
    {
        _man.DeathMan += Reload;
    }

    private void OnDisable()
    {
        _man.DeathMan -= Reload;
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
