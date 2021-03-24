using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetector))]
public class Jumper : MonoBehaviour
{
    public float jumpForce = 2.5f;

    private Rigidbody2D myRigidbody2D;
    private GroundDetector groundDetector;

    public void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        groundDetector = GetComponent<GroundDetector>();
    }

    public void Jump()
    {
        if (groundDetector.onGround == true)
        {
            myRigidbody2D.velocity += new Vector2(0f, jumpForce);
        }
    }
}
