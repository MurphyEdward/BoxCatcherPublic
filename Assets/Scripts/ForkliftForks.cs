using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ForkliftForks : MonoBehaviour
{
    [SerializeField] private UnityEvent<List<GameObject>> _collidedWithBoxCarrier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.TryGetComponent<BoxCarrier>(out BoxCarrier boxCarrier))
        {
            _collidedWithBoxCarrier?.Invoke(boxCarrier.GiveCarriedBoxes());

        }
    }
}
