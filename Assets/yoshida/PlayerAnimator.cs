using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int isWalkingHash = Animator.StringToHash("isWalking");
    private static readonly int isJumpnigHash = Animator.StringToHash("isJumping");
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartWalkingAnimation()
    {
        _animator.SetBool(isWalkingHash, true);
    }

    public void StartJumpingAnimation()
    {
        _animator.SetBool(isJumpnigHash,true);
    }

    public void StopWalkingAnimation()
    {
        _animator.SetBool(isWalkingHash, false);
    }

    public void StopJumpingAnimation()
    {
        _animator.SetBool(isJumpnigHash, false);
    }

    public bool isJumping()
    {
        return _animator.GetBool(isJumpnigHash);
    }
}
