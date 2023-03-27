using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Toggle : MonoBehaviour
{
    private const float _toggledOffVolume = 0;

    private Image _toggleImage;

    private void Awake()
    {
        Image _toggleImage = GetComponent<Image>();
    }

    /*private void UpdateSprite()
    {
       
        

        if (_isToggleTurnedOn)
        {
            toggleImage.sprite = toggleTurnedOn;
            return;
        }

        toggleImage.sprite = toggleTurnedOff;
    }*/
}
