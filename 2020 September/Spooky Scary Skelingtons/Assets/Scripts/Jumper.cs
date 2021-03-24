using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GroundDetector))]
public class Jumper : MonoBehaviour
{
    public float jumpForce = 2.5f;

    private Rigidbody myRigidbody;
    private GroundDetector groundDetector;

    public void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        groundDetector = GetComponent<GroundDetector>();
    }

    public void Jump()
    {
        if (groundDetector.onGround == true)
        {
            myRigidbody.velocity += new Vector3(0f, jumpForce, 0f);
        }
    }
}
