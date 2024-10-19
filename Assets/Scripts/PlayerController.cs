using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]

public class PlayerController : MonoBehaviour
{
    public bool isDead;
    Animator anim;

    public float walkspeed = 5f;
    public float jumpForce = 1f;
    public float jumpCooldown = 0.1f;
    public float jumpImpulse = 10f;
    private bool _isMoving = false;

    public bool canAttack;
    public float attackCoolDown;
    public bool attack1;
    public bool attack2;

    SpriteRenderer rend;
    Vector2 moveInput;
    TouchingDirections touchingDirections;

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

        
    }
    

    private void FixedUpdate()
    {
        if (isDead) return; // Stop all movement if dead

        rb.velocity = new Vector2(moveInput.x * walkspeed, rb.velocity.y);

        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (isDead) return; // Prevent movement if dead
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput.x != 0;
        if(moveInput.x > 0)
        {
            rend.flipX = true;
        }
        else if(moveInput.x < 0)
        {
            rend.flipX = false;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (isDead || !canAttack) return; // Prevent attack if dead

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
        if (isDead || !context.started || !touchingDirections.IsGrounded) return; // Prevent jump if dead

        if (context.started && touchingDirections.IsGrounded)
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.AddForce(Vector2.up * jumpForce / 100);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }

    // Example method to call when the player dies
    public void Die()
    {
        isDead = true;
        animator.SetTrigger("Die"); // Trigger death animation if any
        // You can also handle other death-related logic here (e.g., disable input, show game over screen, etc.)
    }
}
