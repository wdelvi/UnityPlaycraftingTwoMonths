﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public Mover controlledMover;

    public Jumper controlledJumper;

    private float standardScale;

    public void Start()
    {
        standardScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update () 
    {
        if( Input.GetKey( KeyCode.RightArrow ) || Input.GetKey( KeyCode.D ) )
        {
            Vector2 newScale = transform.localScale;
            newScale.x = standardScale;
            transform.localScale = newScale;

            controlledMover.AccelerateInDirection( new Vector3( 1.0f, 0f, 0f ) );
        }

        if( Input.GetKey( KeyCode.LeftArrow ) || Input.GetKey( KeyCode.A ) )
        {
            Vector2 newScale = transform.localScale;
            newScale.x = -standardScale;
            transform.localScale = newScale;

            controlledMover.AccelerateInDirection( new Vector3( -1.0f, 0f ) );
        }

        if( Input.GetKey( KeyCode.UpArrow ) || Input.GetKey( KeyCode.W )  )
        {
            controlledJumper.Jump();
        }
	}
}