using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSpriteChanger : MonoBehaviour
{
    private const float _toggledOffVolume = 0;

    [SerializeField] private AudioSource _sampleAudioSource;
    [SerializeField] private Sprite _toggleTurnedOn;
    [SerializeField] private Sprite _toggleTurnedOff;
    private Image _toggleImage;

    private void Start()
    {
        _toggleImage = GetComponent<Image>();
        ChangeSprite();
    }

    public void ChangeSprite()
    {
        if(_sampleAudioSource.volume > _toggledOffVolume)
        {
            _toggleImage.sprite = _toggleTurnedOn;
            return;
        }

        _toggleImage.sprite = _toggleTurnedOff;
    }
}
