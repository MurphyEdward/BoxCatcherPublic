using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScreenTouchDetector : MonoBehaviour
{
    [SerializeField] private List<RectTransform> _UIObjectsToIgnoreOnTouch;
    [SerializeField] private UnityEvent LeftPartOfScreenTouched;
    [SerializeField] private UnityEvent RightPartOfScreenTouched;
    [SerializeField] private UnityEvent ScreenIsNotTouched;
    [SerializeField] private UnityEvent ScreenIsFrozen;
    

    public bool PlayerIsStunned;

    private void Update()
    {
        if (PlayerIsStunned)
        {
            ScreenIsFrozen?.Invoke();
            return;
        }

        if (!IsScreenTouched() || GameStatusChanger.IsGamePaused)
        {
            ScreenIsNotTouched?.Invoke();
            return;
        }



        DetectTouchPosition();
    }

    private bool IsScreenTouched()
    {
        return Input.touchCount > 0;
    }

    private void DetectTouchPosition()
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touchPosition = touch.position;
        
        if(IsButtonTouched(touchPosition))
        {
            return;
        }

        if (touch.phase == TouchPhase.Ended)
        {
            ScreenIsNotTouched?.Invoke();
            return;
        }

        if (touchPosition.x > Screen.width / 2)
        {
            RightPartOfScreenTouched?.Invoke();
            return;

        }

        LeftPartOfScreenTouched?.Invoke();                    
    }

    private bool IsButtonTouched(Vector2 touchPosition)
    {
        Vector2 worldTouchPosition = Camera.main.ScreenToWorldPoint(touchPosition);

        foreach(RectTransform UIObjectToIgnore in _UIObjectsToIgnoreOnTouch)
        {
            BoxCollider2D UIObjectCollider = UIObjectToIgnore.GetComponent<BoxCollider2D>();
            if(UIObjectCollider.bounds.Contains(worldTouchPosition))
            {
                return true;
            }
        }
        return false;
    }
}

