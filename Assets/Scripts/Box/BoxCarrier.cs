using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxCarrier : MonoBehaviour
{
    [SerializeField, Range(2, 4)] private int _limitOfBoxes;
    [SerializeField] private UnityEvent _boxCollided;
    [SerializeField] private UnityEvent _boxCarrierAlmostFull;
    [SerializeField] private UnityEvent _boxCarrierReceivedBoxes;

    private List<GameObject> _carriedBoxes = new();
    private GameObject _lastCollidedBox;

    public List<GameObject> CarriedBoxes => new(_carriedBoxes);
    public GameObject LastCollidedBox => _lastCollidedBox;
    public int CarriedBoxesCount => _carriedBoxes.Count;
    public bool IsBoxCarrierAlmostFull => _carriedBoxes.Count == _limitOfBoxes - 1;
    public bool IsBoxCarrierFull => _carriedBoxes.Count == _limitOfBoxes;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out BoxBehaviour boxBehaviour))
        {
            return;
        }

        if (IsBoxCarrierFull)
        {
            boxBehaviour.DestroyBox();
            return;
        }

        _lastCollidedBox = collision.gameObject;
        _lastCollidedBox.GetComponent<SpriteRenderer>().sortingOrder = _carriedBoxes.Count + 1;
        _carriedBoxes.Add(_lastCollidedBox);
        _boxCollided?.Invoke();

        if(IsBoxCarrierAlmostFull)
        {
            _boxCarrierAlmostFull?.Invoke();
        }
    }

    public void DestroyCarriedBoxes()
    {
        foreach (GameObject _caughtBoxObject in _carriedBoxes)
        {
            Destroy(_caughtBoxObject);
        }

        _carriedBoxes = new();
    }

    public List<GameObject> GiveCarriedBoxes()
    {
        List<GameObject> temporaryBoxStorage = new(_carriedBoxes);
        _carriedBoxes = new();

        return temporaryBoxStorage;
    }

    public void ReceiveBoxes(List<GameObject> boxes)
    {
        foreach(GameObject box in boxes)
        {
            if(box.TryGetComponent<BoxBehaviour>(out BoxBehaviour boxBehaviour))
            {
                _carriedBoxes.Add(box);
            }
        }
        _boxCarrierReceivedBoxes?.Invoke();
    }
}
