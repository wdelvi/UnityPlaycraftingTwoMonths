﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 
{
    public float acceleration = 4.0f;
    public float maximumSpeed = 8f;
    public bool canMove = true;

    public void AccelerateInDirection( Vector3 direction )
    {
        if( canMove == false )
        {
            return;
        }

        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        Vector3 newVelocity = myRigidbody.velocity + direction * acceleration * Time.deltaTime;
        newVelocity.x = Mathf.Clamp(newVelocity.x, -maximumSpeed, maximumSpeed);
        newVelocity.y = Mathf.Clamp(newVelocity.y, -maximumSpeed, maximumSpeed);
        newVelocity.z = Mathf.Clamp(newVelocity.z, -maximumSpeed, maximumSpeed);
        myRigidbody.velocity = newVelocity;
    }
}
