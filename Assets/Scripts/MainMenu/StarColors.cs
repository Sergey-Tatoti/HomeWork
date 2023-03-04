using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StarColors : MonoBehaviour
{
    [SerializeField] private Color[] _color;
    [SerializeField] private GameObject _star;
    [SerializeField] private int _speed;

    public void OnClckButton()
    {
        _star.GetComponent<Image>().DOColor(_color[Random.Range(0,_color.Length)], _speed);
    }
}
