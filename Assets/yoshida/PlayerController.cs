using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Events;
using System;
using UnityEngine.LowLevel;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(GroundCheck))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D playerRigidbody;
    private bool canMove;
    private bool canJump;

    private GroundCheck check;
    private PlayerAnimator playerAnimator;

    private Transform spriteTransform;

    void Start()
    {
       Initialize();
    }

    void FixedUpdate()
    {
        if(!GameOverManager.Instance.IsGameOver)
        {
            PlayerMove();
        }
    }

    private void Update()
    {
        canJump = check.CheckGroundStatus();

        

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            SoundManager.Instance.Play(SoundManager.Instance.jump);
            playerRigidbody.velocity = new Vector2(transform.position.x, jumpForce);
            playerAnimator.StartJumpingAnimation();
        }

        if(transform.position.y <= -7f)
        {
            GameOverManager.Instance.SetGameOver(true);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
            Debug.Log("Touch to Floor");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = false;
            Debug.Log("Release from Floor");
        }
    }*/

    private void PlayerMove()
    {
        if (canMove)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");

            if (moveHorizontal != 0)
            {
                if (moveHorizontal < 0)
                {
                    spriteTransform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                else if (moveHorizontal > 0)
                {
                    spriteTransform.rotation = Quaternion.identity;
                }
                playerRigidbody.velocity = new Vector2(moveHorizontal * moveSpeed, playerRigidbody.velocity.y);

                if(canJump)
                {
                    playerAnimator.StartWalkingAnimation();
                }
                
            }
            else
            {
                playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);
                playerAnimator.StopWalkingAnimation();
            }
        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }

    private void Initialize()
    {
        canJump = false;
        canMove = true;
        playerRigidbody = GetComponent<Rigidbody2D>();
        check = GetComponent<GroundCheck>();
        playerAnimator = transform.GetChild(0).gameObject.GetComponent<PlayerAnimator>();
        spriteTransform = transform.GetChild(0).gameObject.transform;
        GoalManager.Instance.IsGoalProp.
            TakeUntilDestroy(this).Where(value => value).Subscribe(_ => canMove = false);

        check.IsPlayerLanded.
            TakeUntilDestroy(this).Where(value => value).Subscribe(_ => playerAnimator.StopJumpingAnimation());
    }
}
