using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jumper : MonoBehaviour
{
    public float jumpForce = 2.5f;

    private Animator animator;
    private Rigidbody myRigidbody;
    private GroundDetector groundDetector;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        groundDetector = GetComponent<GroundDetector>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if(animator != null)
        {
            animator.SetFloat("yVelocity", myRigidbody.velocity.y);
        }
    }

    public void Jump()
    {
        if (groundDetector == null || groundDetector.onGround == true)
        {
            myRigidbody.velocity += new Vector3(0f, jumpForce, 0f);

            if (myRigidbody.velocity.y > jumpForce)
            {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpForce, myRigidbody.velocity.z);
            }
        }
    }
}
