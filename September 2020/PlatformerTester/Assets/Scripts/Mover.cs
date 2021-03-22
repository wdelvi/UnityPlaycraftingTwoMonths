using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    public float acceleration = 5f;
    public float maximumSpeed = 10f;

    private Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void AccelerateInDirection( Vector2 direction )
    {
        direction = Vector3.Normalize(direction);

        Vector2 newVelocity = myRigidbody2D.velocity +
            (direction * acceleration * Time.deltaTime);

        newVelocity.x = Mathf.Clamp(newVelocity.x, -maximumSpeed, maximumSpeed);

        myRigidbody2D.velocity = newVelocity;
    }
}
