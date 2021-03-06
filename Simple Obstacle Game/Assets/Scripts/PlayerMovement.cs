﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb = null;
    [SerializeField] private float _forwardForce = 2000f;
    [SerializeField] private float _sideForce = 500f;
    [SerializeField] private float _maxSpeed = 125f;
    [SerializeField] private PlayerMovement _playerMoveScript = null;
    public Vector3 _centerOfMass;

    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // Use "FixedUpdate" for PHYSICS!
    void FixedUpdate()
    {
        // add a forward force to player
        _rb.AddForce(0, 0, _forwardForce * Time.deltaTime);        // delta time is used to create frame rate independent movement

        if (Input.GetKey("d"))
        {
            _rb.AddForce(_sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (Input.GetKey("a"))
        {
            _rb.AddForce(-_sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        LockSpeed();

        if (_rb.position.y < -0.5f)
        {
            enabled = false;            // disabling this script
            //FindObjectOfType<GameManager>().EndGame();
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm.isLevelCompleted == false)
            {
                gm.EndGame();
            }
        }

        _rigidBody.centerOfMass = _centerOfMass;
        
    }

    private void LockSpeed()
    {
        if (_rb.velocity.magnitude > _maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * _centerOfMass, 0.8f);
    }
}

// https://github.com/Triple3Apple