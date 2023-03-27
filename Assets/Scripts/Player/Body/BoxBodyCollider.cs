using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class BoxBodyCollider : MonoBehaviour
{
    public static event Action RunOutOfHealth;

    [SerializeField] private UnityEvent _removedBox;
    [SerializeField] private UnityEvent _stunEnded;
    [SerializeField] private LevelInfo _levelInfo;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private ScreenTouchDetector _screenTouchDetector;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField, Range(1, 10)] private int _stunDuration;
    [SerializeField, Range(1, 10)] private int _damageFromBox;
    private int _sumDamage = 0;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BoxBehaviour boxBehaviour))
        {
            _removedBox?.Invoke();
            AssignLevelDamageModificator();
            AssignLevelStunDuration();
            boxBehaviour.PlayPlayerCollisionSound();
            boxBehaviour.DestroyBox();
            CalculateDamage();
            StunThePlayer();
        }
    }

    private void AssignLevelDamageModificator()
    {
        if (_levelInfo.Settings == null)
        {
            return;
        }
        _damageFromBox = _levelInfo.Settings.LevelDamageModifier;

    }
    private void AssignLevelStunDuration()
    {
        if (_levelInfo.Settings == null)
        {
            return;
        }
        _stunDuration = _levelInfo.Settings.StunDuration;
    }

    public void StunThePlayer()
    {
        _screenTouchDetector = GameObject.Find("Player").GetComponent<ScreenTouchDetector>();
        _screenTouchDetector.PlayerIsStunned = true;
        StartCoroutine(SetStanDuration());


    }

    IEnumerator SetStanDuration()
    {
        yield return new WaitForSeconds(_stunDuration);
        _screenTouchDetector.PlayerIsStunned = false;
        _stunEnded?.Invoke();



    }

        private void CalculateDamage()
    {
        _playerHealth = GameObject.Find("Body").GetComponent<PlayerHealth>();
        _sumDamage += _damageFromBox;

        if (_playerHealth.HitPoints - _sumDamage <= 0)
        {
            RunOutOfHealth?.Invoke();
        }
    }





}
