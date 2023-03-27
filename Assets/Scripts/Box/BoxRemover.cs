using UnityEngine;
using UnityEngine.Events;

public class BoxRemover : MonoBehaviour
{
    [SerializeField] private UnityEvent _removedBox;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BoxBehaviour boxBehaviour))
        {
            _removedBox?.Invoke();
            boxBehaviour.PlayGroundCollisionSound();
            boxBehaviour.DestroyBox();
        }
    }
}
