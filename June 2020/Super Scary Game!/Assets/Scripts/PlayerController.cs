using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Mover mover;
    private Jumper jumper;
    private Rotator rotator;

    void Start()
    {
        mover = gameObject.GetComponent<Mover>();
        jumper = gameObject.GetComponent<Jumper>();
        rotator = gameObject.GetComponent<Rotator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Strafe Right
        if (Input.GetKey(KeyCode.E))
        {
            mover.AccelerateInDirection(transform.right);
        }

        //Strafe Left
        if (Input.GetKey(KeyCode.Q))
        {
            mover.AccelerateInDirection(transform.right * -1);
        }

        //Rotate Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rotator.RotateTowardsDirection(transform.right);
        }

        //Rotate Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rotator.RotateTowardsDirection(transform.right * -1);
        }

        //Forward
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            mover.AccelerateInDirection(transform.forward);
        }

        //Backward
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            mover.AccelerateInDirection(transform.forward * -1);
        }

        //Jump
        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            jumper.Jump();
        }
    }
}
