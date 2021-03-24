using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    public float acceleration = 10f;
    public float maximumSpeed = 15f;

    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void AccelerateInDirection( Vector3 direction )
    {
        direction = Vector3.Normalize(direction);

        Vector3 newVelocity = myRigidbody.velocity +
            (direction * acceleration * Time.deltaTime);

        newVelocity.x = Mathf.Clamp(newVelocity.x, -maximumSpeed, maximumSpeed);

        myRigidbody.velocity = newVelocity;
    }
}
