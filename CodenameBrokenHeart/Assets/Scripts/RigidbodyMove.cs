using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class RigidbodyMove : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //get input axes (arrow keys)
        float moveHorizontal = Input.GetAxis("Horiaontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Create movement direction vector
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        //Move the rigidbody position relative to fixed time step.
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

}

