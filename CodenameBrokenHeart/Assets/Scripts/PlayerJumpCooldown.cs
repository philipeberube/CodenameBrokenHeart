using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayerJumpCooldown : MonoBehaviour
    {
        public Rigidbody2D rb;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float jumpCooldown = 0.1f;
        [SerializeField] private float nextJumpTime = 0f;
        [SerializeField] private float attackCooldown = 0.1f;
        [SerializeField] private float nextAttackTime = 0f;
        [SerializeField] Transform groundCheck;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] private float checkRadius = 0.1f;
        [SerializeField] private bool isGrounded = false;
        [SerializeField] public Animator animator;
        [SerializeField] public bool isTransitionMuted = false;
        [SerializeField] private float nextAnimTime = 0f;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {

            animator.SetBool("isBrawl", false);
            animator.SetBool("isAA", false);

            if(Time.time >= nextAnimTime)
            {
                isTransitionMuted = false;
            }

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
            if (Input.GetKeyDown(KeyCode.X) && isGrounded && Time.time >= nextJumpTime)
            {
                Jump();
                
            }
            else if (Input.GetKeyDown(KeyCode.Z) && Time.time >= nextAttackTime )
            {
                attack();
            }
        }

        void attack()
        {
            if (isGrounded)
            {
                animator.SetBool("isBrawl", true);
            }
            else
            {

                animator.Play("aerialbrawl");
                isTransitionMuted = true;
                nextAnimTime = 1f;
                
            }


            nextAttackTime = Time.time + attackCooldown;
        }

        void Jump()
        {
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            nextJumpTime = Time.time + jumpCooldown;
        }
    }
}
