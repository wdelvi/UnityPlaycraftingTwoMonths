using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour 
{
    public float jumpImpulse = 5f;

    public float jumpDelay = 0.5f;

    private float lastTimeJumped;

    private GroundDetector groundDetector;

    public void Start()
    {
        groundDetector = GetComponent<GroundDetector>();
    }

    public void Jump()
    {
        float timeSinceJumped = Time.time - lastTimeJumped;
        
        if (timeSinceJumped >= jumpDelay && groundDetector.isOnGround)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
            lastTimeJumped = Time.time;
        }
    }
}
