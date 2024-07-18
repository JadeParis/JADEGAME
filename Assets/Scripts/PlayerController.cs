using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public float walkspeed = 5f;
    public float jumpForce = 1f;
    public float jumpCooldown = 0.1f;
    SpriteRenderer rend;
    Vector2 moveInput;
    TouchingDirections touchingDirections;
    private bool _isMoving = false;
    bool canJump;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkspeed, rb.velocity.y);
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

    public void OnJump(InputAction.CallbackContext context)
    {
        if (touchingDirections.IsGrounded && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce / 100);
            canJump = false;
            Invoke("JumpCooldown", jumpCooldown);
        }
    }

    void JumpCooldown()
    {
        canJump = true;
    }
}
