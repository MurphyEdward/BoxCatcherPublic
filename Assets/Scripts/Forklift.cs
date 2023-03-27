using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Forklift : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _forkliftIsGone;
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _destinationX = 11.0f;
   
    private List<GameObject> _boxes;
    private Vector2 _spawnPointRight;
    private Vector2 _spawnPointLeft;
    private bool _isSpawnedOnLeft;
    private bool _isGoingForward;
    private bool _isGoingBackwards;

    public bool IsSpawned { get; private set; } = false;

    private void Awake()
    {
        _spawnPointRight = new Vector3(transform.position.x, transform.position.y, 0);
        _spawnPointLeft = new Vector3(-_spawnPointRight.x, _spawnPointRight.y, 0);
    }

    private void Update()
    {
        if (!IsSpawned)
        {
            return;
        }

        if (_isGoingForward)
        {
            ForwardMovement();
        }


        if (_isGoingBackwards)
        {
            BackwardsMovement();
        }
    }

    private void ForwardMovement()
    {
        if (IsForwardPointNotReached())
        {
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
            return;
        }
        _isGoingForward = false;
    }

    private bool IsForwardPointNotReached()
    {
        return transform.position.x > _destinationX || transform.position.x < -_destinationX;
    }

    private void BackwardsMovement()
    {
        if (IsBackwardsPointNotReached())
        {
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
            return;
        }
        _isGoingBackwards = false;
        gameObject.SetActive(false);
        _forkliftIsGone?.Invoke();
        _animator.GetComponent<Animator>().Play("Forklift_Lift_Reverse", -1, 0f);
    }

    private bool IsBackwardsPointNotReached()
    {
        if (_isSpawnedOnLeft)
        {
            return transform.position.x > _spawnPointLeft.x;
        }
        return transform.position.x < _spawnPointRight.x;
    }

    public void Spawn()
    {
        RandomizeSpawnPosition();
        SpawnBasedOnRandomizedPosition();

        gameObject.SetActive(true);
        IsSpawned = true;
        _isGoingForward = true;

    }

    private void RandomizeSpawnPosition()
    {
        if (Random.Range(0, 2) == 1) 
        { 
            _isSpawnedOnLeft = true;
            return;
        }
        _isSpawnedOnLeft = false;
    }

    private void SpawnBasedOnRandomizedPosition()
    {
        if (_isSpawnedOnLeft)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            transform.position = _spawnPointLeft;
            return;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        transform.position = _spawnPointRight;
    }

    public void TookBoxes()
    {
        _isGoingForward = false;
        _isGoingBackwards = true;
    }

    public void PlayLiftingAnimation()
    {
        _animator.GetComponent<Animator>().Play("Forklift_Lift", -1, 0f);
    }

}
