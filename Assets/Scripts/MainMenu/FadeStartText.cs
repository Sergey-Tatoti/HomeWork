using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeStartText : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Text _text;

    private void Awake() 
    {
        _text = GetComponent<Text>();
    }

    private void Start() 
    {
        _text.DOFade(0, _speed).SetLoops(-1, LoopType.Yoyo);
    }
}
