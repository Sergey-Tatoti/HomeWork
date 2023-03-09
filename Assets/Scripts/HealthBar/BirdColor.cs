using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]

public class BirdColor : MonoBehaviour
{
    [SerializeField] private float _duration;

    private Color _colorGetHit;
    private Color _colorGetHealth;
    private Color _colorOriginal;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _colorGetHit = Color.red;
        _colorGetHealth = Color.green;
        _colorOriginal = _spriteRenderer.color;
    }

    public void GetHit()
    {
        ChangeColor(_colorGetHit, _colorOriginal);
    }

    public void GetHealth()
    {
        ChangeColor(_colorGetHealth, _colorOriginal);
    }

    private void ChangeColor(Color ReceivedColor, Color OriginalColor)
    {
        if(_spriteRenderer.color == OriginalColor)
        {
        _spriteRenderer.color = ReceivedColor;
        _spriteRenderer.DOColor(OriginalColor, _duration);
        }
    }
}