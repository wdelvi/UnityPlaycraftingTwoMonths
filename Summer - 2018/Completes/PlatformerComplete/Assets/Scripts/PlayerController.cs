using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public Mover controlledMover;

    public Jumper controlledJumper;

	// Update is called once per frame
	void Update () 
    {
        if( Input.GetKey( KeyCode.RightArrow ) )
        {
            controlledMover.AccelerateInDirection( new Vector3( 1.0f, 0f, 0f ) );
        }

        if( Input.GetKey( KeyCode.LeftArrow ) )
        {
            controlledMover.AccelerateInDirection( new Vector3( -1.0f, 0f ) );
        }

        if( Input.GetKey( KeyCode.UpArrow ) )
        {
            controlledJumper.Jump();
        }
	}
}
