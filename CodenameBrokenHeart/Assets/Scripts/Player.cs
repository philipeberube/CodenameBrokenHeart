using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpCooldown = 0.1f;
    [SerializeField] private float nextJumpTime = 0f;
    [SerializeField] private float attackCooldown = 0.1f;
    [SerializeField] private float nextAttackTime = 0f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private float checkRadius = 0.1f;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] public bool isTransitionMuted = false;
    [SerializeField] private float nextAnimTime = 0f;

    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Animator animator;
    [SerializeField] private float speed = .1f;
    [SerializeField] private Transform transformComponent;
    [SerializeField] public Rigidbody2D rb;
    //[SerializeField] private float jumpForce = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //HandleMovement();
    }

    void FixedUpdate()
    {

        animator.SetBool("isBrawl", false);
        animator.SetBool("isAA", false);

        if (Time.time >= nextAnimTime)
        {
            isTransitionMuted = false;
        }

        isGrounded = Physics2D.OverlapCircle(transformComponent.position, checkRadius, groundLayer);
        if (Input.GetKeyDown(KeyCode.X) && isGrounded && Time.time >= nextJumpTime)
        {
            Jump();

        }
        else if (Input.GetKeyDown(KeyCode.Z) && Time.time >= nextAttackTime)
        {
            attack();
        }


        Movement();
        //Jump();
    }

    private void Movement()
    {
        float input = Input.GetAxisRaw("Horizontal");
        float input2 = rb.linearVelocityY;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transformComponent.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transformComponent.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transformComponent.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transformComponent.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }


        if (input2 != 0 && !isTransitionMuted)
        {
            if (input2 > 0)
            {
                animator.SetBool("isJump", true);
                animator.SetBool("isFall", false);
            }
            else
            {
                animator.SetBool("isFall", true);
                animator.SetBool("isJump", false);
            }
        }
        else
        {
            animator.SetBool("isJump",  false);
            animator.SetBool("isFall", false);
        }


        if (input != 0)
        {
            animator.SetBool("isRunning", true);
            
            spriteRenderer.flipX = input < 0;
        }
        else
        {
            animator.SetBool("isRunning", false);
            //aa
        }

    }

    

    private void attack()
    {
        if (isGrounded)
        {
            animator.SetBool("isBrawl", true);
        }
        else
        {

            animator.Play("aerialbrawl");
            isTransitionMuted = true;
            nextAnimTime = Time.time + 0.5f;

        }


        nextAttackTime = Time.time + attackCooldown;
    }

    private void Jump()
    {

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        nextJumpTime = Time.time + jumpCooldown;
    }

    //private void Jump()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    //    }
    //}
    //private void HandleMovement()
    //{
    //    // Locks rotation directly in code so the physics engine cannot tilt the character
    //    //playerRb.freezeRotation = true;

    //    float input = Input.GetAxisRaw("Horizontal");

    //    // Explicitly sets the Y value to 0 to prevent erratic vertical flying
    //    Vector2 movement = new Vector2(input * speed * Time.deltaTime, 0);
    //    transform.Translate(movement);

    //    if (input != 0)
    //    {
    //        //_animator.SetBool("isRunning", true);
    //        // Replaces your buggy FlipCharacterX logic to stop the rapid visual flickering
    //        //spriteRenderer.flipX = input < 0;
    //    }
    //    else
    //    {
    //        //_animator.SetBool("isRunning", false);
    //    }


    //}


}
