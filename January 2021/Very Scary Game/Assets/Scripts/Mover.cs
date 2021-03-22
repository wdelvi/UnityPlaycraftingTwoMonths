using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    public float acceleration = 5f;
    public float maximumSpeed = 10f;

    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void AccelerateInDirection( Vector3 direction )
    {
        //Normalize just means... set between 0 and 1 so that it only represents direction
        direction = Vector3.Normalize(direction);

        //Make our velocity faster depending on acceleration and frame rate
        Vector3 newVelocity = myRigidbody.velocity +
            (direction * acceleration * Time.deltaTime);

        //Set maximum speeds in both directions
        newVelocity.x = Mathf.Clamp(newVelocity.x, -maximumSpeed, maximumSpeed);
        newVelocity.y = Mathf.Clamp(newVelocity.y, -maximumSpeed, maximumSpeed);
        newVelocity.z = Mathf.Clamp(newVelocity.z, -maximumSpeed, maximumSpeed);

        myRigidbody.velocity = newVelocity;
    }
}
