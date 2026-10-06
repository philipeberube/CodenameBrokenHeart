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
        [SerializeField] Transform groundCheck;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] private float checkRadius = 0.1f;
        [SerializeField] private bool isGrounded = false;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && Time.time >= nextJumpTime)
            {
                Jump();
                
            }
        }

        void Jump()
        {
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            nextJumpTime = Time.time + jumpCooldown;
        }
    }
}
