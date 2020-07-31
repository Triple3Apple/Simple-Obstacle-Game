using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forwardForce = 2000f;
    [SerializeField] private float sideForce = 500f;
    [SerializeField] private float maxSpeed = 125f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Use "FixedUpdate" for PHYSICS!!!
    void FixedUpdate()
    {
        // add a forward force to player
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);        // delta time is used to create frame rate independent movement

        if (Input.GetKey("d"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("a"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0);
        }

        Debug.Log(rb.velocity);

        //rb.velocity = constantSpeed * (rb.velocity.normalized);

        LockSpeed();
        
    }

    private void LockSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
