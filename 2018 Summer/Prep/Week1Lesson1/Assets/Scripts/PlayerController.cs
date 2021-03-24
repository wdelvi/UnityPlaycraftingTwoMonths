using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public Mover controlledMover;

    public void Update()
    {
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            controlledMover.AccelerateInDirection( new Vector3( 1.0f, 0.0f ) );
        }

        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            controlledMover.AccelerateInDirection( new Vector3( -1.0f, 0.0f ) );
        }

        if ( Input.GetKey( KeyCode.Space ) )
        {
            GetComponent<Jumper>().Jump();
        }
    }
}
