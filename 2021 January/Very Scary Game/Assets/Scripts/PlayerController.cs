using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
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
        //Rotate or strafe Left
        if ( Input.GetKey(KeyCode.A) )
        {
            if (rotator != null)
            {
                rotator.RotateTowardsDirection(-transform.right);
            }
            else
            {
                mover.AccelerateInDirection(-transform.right);
            }
        }

        //Rotate or strafe Right
        if (Input.GetKey(KeyCode.D))
        {
            if( rotator != null )
            {
                rotator.RotateTowardsDirection(transform.right);
            }
            else
            {
                mover.AccelerateInDirection(transform.right);
            }
        }

        //Forward
        if (Input.GetKey(KeyCode.W))
        {
            mover.AccelerateInDirection(transform.forward);
        }

        //Back
        if (Input.GetKey(KeyCode.S))
        {
            mover.AccelerateInDirection(-transform.forward);
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumper.Jump();
        }

    }
}
