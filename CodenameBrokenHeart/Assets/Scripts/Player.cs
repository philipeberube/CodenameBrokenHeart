using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Animator animator;
    [SerializeField] private float speed = .1f;
    [SerializeField] private Transform transformComponent;
    [SerializeField] public Rigidbody2D rigidbody;
    //[SerializeField] private float jumpForce = 5f;
    private Rigidbody2D rb;
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
        Movement();
        //Jump();
    }

    private void Movement()
    {
        float input = Input.GetAxisRaw("Horizontal");
        float input2 = rigidbody.linearVelocityY;

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


        if (input2 != 0)
        {
            animator.SetFloat("isJump",  input2);
        }
        else
        {
            animator.SetFloat("isJump",  0);
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
