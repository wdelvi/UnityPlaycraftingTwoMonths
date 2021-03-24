using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Rotator))]
public class PlayerController : MonoBehaviour
{
    private Mover mover;
    private Jumper jumper;
    private Rotator rotator;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        jumper = GetComponent<Jumper>();
        rotator = GetComponent<Rotator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate Left
        if (Input.GetKey(KeyCode.A))
        {
            rotator.RotateTowardsDirection(-transform.right);
        }

        //Rotate Right
        if (Input.GetKey(KeyCode.D))
        {
            rotator.RotateTowardsDirection(transform.right);
        }

        //Move Forward
        if (Input.GetKey(KeyCode.W))
        {
            mover.AccelerateInDirection(transform.forward);
        }

        //Move Backward
        if (Input.GetKey(KeyCode.S))
        {
            mover.AccelerateInDirection(-transform.forward);
        }

        //Jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumper.Jump();
        }
    }
}
