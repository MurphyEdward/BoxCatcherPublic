using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class PlayerAnimation : MonoBehaviour
{
    private const string IsWalking = "isWalking";
    private const string PlayerWalk = "Player_Walk";
    private const string PlayerIdle = "Player_Idle";

    private Animator _playerAnimator;
    private PlayerMove _playerMove;

    private void Awake()
    {
        _playerAnimator = gameObject.GetComponent<Animator>();
        _playerMove = gameObject.GetComponentInParent<PlayerMove>();
    }

    public void AnimateWalking()
    {
        _playerAnimator.SetBool(IsWalking, true);
    }

    public void AnimateIdle()
    {
        _playerAnimator.SetBool(IsWalking, false);
    }
}
