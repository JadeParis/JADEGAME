using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]

public class PlayerController : MonoBehaviour
{
    public float walkspeed = 5f;
    public float jumpForce = 1f;
    public float jumpCooldown = 0.1f;
    public float jumpImpulse = 10f;
    SpriteRenderer rend;
    Vector2 moveInput;
    TouchingDirections touchingDirections;
    private bool _isMoving = false;
    bool canJump;

    public bool canAttack;
    public float attackCoolDown;
    public bool attack1;
    public bool attack2;

    public bool IsMoving { get
        {
            return _isMoving;
        }
        private set 
        { 
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }

    private bool _isRunning = false;

    public bool IsRunning 
    { 
        get
        {
         return _isRunning;
        } 
        set 
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }

    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        touchingDirections = GetComponent<TouchingDirections>();
        canJump = true;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkspeed, rb.velocity.y);

        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;
        if(moveInput.x > 0)
        {
            rend.flipX = true;
        }
        else if(moveInput.x < 0)
        {
            rend.flipX = false;
        }
    }

    public void OnJumps(InputAction.CallbackContext context)
    {
        if (touchingDirections.IsGrounded && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce / 100);
            canJump = false;
            Invoke("JumpCooldown", jumpCooldown);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (canAttack)
        {
            if (attack1)
            {
                animator.SetTrigger("Attack_1");
                //detect if first aniumations playerd, nexty time hit play second one
                canAttack = false;
                attack1 = false;
                attack2 = true;
                StartCoroutine(AttackCoolDown());
            }
            else if (attack2)
            {
                animator.SetTrigger("Attack_2");
                //detect if first aniumations playerd, nexty time hit play second one
                canAttack = false;
                attack2 = false;
                attack1 = true;
                StartCoroutine(AttackCoolDown());
            }
            
        }
    }

    IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(attackCoolDown);
        canAttack = true;

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && touchingDirections.IsGrounded)
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }
}
