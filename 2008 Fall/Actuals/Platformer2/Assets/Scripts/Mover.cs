using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 
{
    public float acceleration = 50.0f;
    public float maximumSpeed = 20.0f;

    public void AccelerateInDirection( Vector2 direction )
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 newVelocity = rb.velocity + direction * acceleration * Time.deltaTime;
        newVelocity.x = Mathf.Clamp( newVelocity.x, -maximumSpeed, maximumSpeed );
        rb.velocity = newVelocity;
    }
}
