using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class UniversalBackground : MonoBehaviour
{
    [SerializeField] LevelInfo _levelInfo;
    private SpriteRenderer _spriteRenderer;

    public void AssignBackground()
    {
        if(_levelInfo.Settings == null)
        {
            return;
        }
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _levelInfo.Settings.Background;
    }
}
