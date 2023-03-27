using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float _speed = 10.0f;
 
    public bool IsPlayerMirroredToRight { get; private set; }

    public void TurnPlayerRight()
    {
        IsPlayerMirroredToRight = true;
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public void TurnPlayerLeft()
    {
        IsPlayerMirroredToRight = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void MovePlayerRight()
    {
        transform.Translate(transform.right * Time.deltaTime * _speed);
    }

    public void MovePlayerLeft()
    {
        transform.Translate(-transform.right * Time.deltaTime * _speed);
    }

    public float GetPlayerSpeed()
    {
        return _speed;
    }
}

