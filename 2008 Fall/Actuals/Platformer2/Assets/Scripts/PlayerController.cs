using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    private Mover controlledMover;
    private Jumper controlledJumper;

    void Start()
    {
        controlledMover = GetComponent<Mover>();
        controlledJumper = GetComponent<Jumper>();
    }

    void Update () 
    {
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            controlledMover.AccelerateInDirection( new Vector2( 1.0f, 0.0f ) );
        }

        if( Input.GetKey( KeyCode.LeftArrow ) )
        {
            controlledMover.AccelerateInDirection( new Vector2( -1.0f, 0.0f ) );
        }

        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            controlledJumper.Jump();
        }
	}
}
