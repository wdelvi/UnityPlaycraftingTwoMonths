using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Mover mover;
    private Rotator rotator;
    private Jumper jumper;

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
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            mover.AccelerateInDirection(transform.right);
        }

        //Strafe Left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            mover.AccelerateInDirection(transform.right * -1);
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
