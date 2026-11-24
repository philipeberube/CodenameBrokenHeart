using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpCooldown = 0f;
    [SerializeField] private float nextJumpOcc = 0f;
    [SerializeField] private float attackCooldown = 0f;
    [SerializeField] private float nextAttackOcc = 0f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private float checkRadius = 0.1f;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] public bool isTransitionMuted = false;
    [SerializeField] private float nextAnimOcc = 0f;
    

    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Animator animator;
    [SerializeField] public float speed = 3f;
    [SerializeField] public PlayerHealth health;
    [SerializeField] public DamageDealer attack;
    [SerializeField] public List<BuffItem> plateInventory;
    [SerializeField] private Transform transformComponent;
    [SerializeField] public Rigidbody2D rb;

    [SerializeField] public Collider2D[] attackColliders;

    public bool isRunning = false;
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
        animator.SetBool("isBrawl", false);
        animator.SetBool("isAA", false);

        if (Time.time >= nextAnimOcc)
        {
            isTransitionMuted = false;
            speed = 4f;

        }


        isGrounded = Physics2D.OverlapCircle(transformComponent.position, checkRadius, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.X) && isGrounded && Time.time >= nextJumpOcc)
        {
            Jump();

        }
        else if (Input.GetKeyDown(KeyCode.Z) && Time.time >= nextAnimOcc)
        {
            Attack();
        }


        Movement();
        //Jump();
    }

    private void Movement()
    {
        float input = Input.GetAxisRaw("Horizontal");
        float input2 = rb.linearVelocityY;

        if (input2 == 0 && isTransitionMuted)
        {
            speed = 1f;
        }

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
            animator.SetBool("isJump", false);
            animator.SetBool("isFall", false);
        }


        if (input != 0)
        {
            animator.SetBool("isRunning", true);
            isRunning = true;


            if (input < 0)
            {
                transform.localScale = new Vector3(-2, 2, 1);
            }
            else
            {
                transform.localScale = new Vector3(2, 2, 1);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
            isRunning = false;
            //aa
        }
        //HandleMovement();
    }

    void FixedUpdate()
    {

        

    }

    

    private void Attack()
    {
        if (isGrounded && !isRunning)
        {
            animator.Play("BrawlIdle");
            isTransitionMuted = true;
            nextAnimOcc = Time.time + 0.5f;
            LaunchAttack(attackColliders[0]);
        }
        else if (isGrounded)
        {
            animator.Play("brawl");
            isTransitionMuted = true;
            nextAnimOcc = Time.time + 0.5f;
            LaunchAttack(attackColliders[1]);
        }
        else
        {

            animator.Play("aerialbrawl");
            isTransitionMuted = true;
            nextAnimOcc = Time.time + 0.5f;
            LaunchAttack(attackColliders[2]);

        }


        //nextAttackOcc = Time.time + attackCooldown;
    }

    private void Jump()
    {

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        nextJumpOcc = Time.time + jumpCooldown;
    }

    private void LaunchAttack(Collider2D col)
    {
        Rigidbody2D test;
        Collider2D[] cols = Physics2D.OverlapBoxAll(col.bounds.center,col.bounds.extents * 2,0 ,LayerMask.GetMask("Hitbox")); //tofix
        foreach (Collider2D c in cols)
        {
            
            Debug.Log(c.name);

            if (c.gameObject.CompareTag("Sloth"))
            {

                Debug.Log("hit!");
                test = c.gameObject.GetComponent<Rigidbody2D>();
                test.linearVelocity = new Vector2(test.linearVelocity.x + transform.localScale.x + rb.linearVelocityX, 3 + rb.linearVelocityY);

            }



        }

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
