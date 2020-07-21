using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float acceleration = 5f;

    public float maximumSpeed = 10f;

    private Rigidbody myRigidbody;

    public void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public void AccelerateInDirection( Vector3 direction )
    {
        direction = Vector3.Normalize(direction);

        Vector3 newVelocity = myRigidbody.velocity + (direction * acceleration * Time.deltaTime);

        newVelocity.x = Mathf.Clamp(newVelocity.x, -maximumSpeed, maximumSpeed);

        myRigidbody.velocity = newVelocity;
    }
}
