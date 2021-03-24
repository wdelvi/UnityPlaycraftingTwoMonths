using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public Mover controlledMover;

    public Jumper controlledJumper;
	
	void Update () 
    {
        if( Input.GetKey( KeyCode.RightArrow ) )
        {
            controlledMover.AccelerateInDirection( new Vector2(1f, 0f) );
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            controlledMover.AccelerateInDirection(new Vector2(-1f, 0f));
        }

        if( Input.GetKey(KeyCode.Space) )
        {
            controlledJumper.Jump();
        }

        if( Input.anyKey == false )
        {
            //set velocity to zero or whatever
        }
    }
}
