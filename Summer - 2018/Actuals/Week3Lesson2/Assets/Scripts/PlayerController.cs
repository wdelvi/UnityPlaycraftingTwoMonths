using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public Mover controlledMover;

    public Jumper controlledJumper;

    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () 
    {
        if( animator )
        {
            animator.SetFloat( "YVelocity", GetComponent<Rigidbody2D>().velocity.y );
        }

        if( Input.GetKey( KeyCode.RightArrow ) )
        {
            MoveRight();
        }

        if( Input.GetKey( KeyCode.LeftArrow ) )
        {
            MoveLeft();
        }

        if( Input.GetKey( KeyCode.UpArrow ) )
        {
            Jump();
        }
	}

    public void MoveRight()
    {
        controlledMover.AccelerateInDirection( new Vector3( 1.0f, 0f, 0f ) );
    }

    public void MoveLeft()
    {
        controlledMover.AccelerateInDirection( new Vector3( -1.0f, 0f ) );
    }

    public void Jump()
    {
        controlledJumper.Jump();
    }
}
