using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 
{
    public float acceleration = 5f;

    public float maximumSpeed = 10f;

    public float minimumSpeed = 0.2f;

    public void AccelerateInDirection( Vector2 direction )
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector2 newVelocity = rb.velocity + ( direction * acceleration * Time.deltaTime );
        newVelocity.x = Mathf.Clamp(newVelocity.x, -maximumSpeed, maximumSpeed);

        rb.velocity = newVelocity;
    }

    public bool IsWalking()
    {
        return Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) >= minimumSpeed;
    }
}