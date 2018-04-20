﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    float horizontalMovement;
    float verticalMovement;

    [SerializeField]
    float rotationSpeed = 1;

    float horizontalRoation;
    float verticalRotation;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovementConroller();
        VerticleMovement();
    }

    void VerticleMovement()
    {
        if(Input.GetButton("UpController"))
        {
            rb.velocity += new Vector3(0, 1);
        }

        if(Input.GetButton("DownController"))
        {
            rb.velocity -= new Vector3(0, 1);
        }
    }

    void MovementConroller()
    {
        horizontalMovement = Input.GetAxis("HorizontalController");
        verticalMovement = Input.GetAxis("VerticalController");

        Vector3 move = new Vector3(horizontalMovement, 0, verticalMovement);



        rb.AddRelativeForce(move * speed);

        if(Input.GetButtonDown("VRSTOP"))
        {
            Debug.Log("Stop is Hit");
            rb.velocity = Vector3.zero;
        }

        //if (Input.GetKeyDown(KeyCode.KeypadEnter))
        //{
        //    this.transform.Rotate(Vector3.zero);
        //}

        //horizontalRoation += .05f * rotationSpeed * Input.GetAxis("HorizontalControllerRight");
        //verticalRotation -= .05f * rotationSpeed * Input.GetAxis("VerticalControllerRight");
        
        //transform.eulerAngles += new Vector3(horizontalRoation, verticalRotation, 0.0f);
        

        
    }
}