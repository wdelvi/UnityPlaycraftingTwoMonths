using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public Mover controlledMover;

    public Jumper controlledJumper;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () 
    {
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

        if( animator )
        {
            animator.SetFloat( "YVelocity", GetComponent<Rigidbody2D>().velocity.y );
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
