using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    public float jumpForce = 2.5f;

    private Animator animator;
    private Rigidbody2D myRigidBody2D;
    private GroundDetector groundDetector;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        groundDetector = GetComponent<GroundDetector>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if(animator != null)
        {
            animator.SetFloat("yVelocity", myRigidBody2D.velocity.y);
        }
    }

    public void Jump()
    {
        if (groundDetector == null || groundDetector.onGround == true)
        {
            myRigidBody2D.velocity += new Vector2(0f, jumpForce);

            if (myRigidBody2D.velocity.y > jumpForce)
            {
                myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, jumpForce);
            }
        }
    }
}
