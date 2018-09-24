﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour 
{
    [HideInInspector]
    public bool isOnGround;

	// Use this for initialization
	void Start () 
    {
        isOnGround = false;	
	}

    public void OnCollisionEnter2D( Collision2D collision )
    {
        if( collision.gameObject.layer == 8 )
        {
            isOnGround = true;
        }
    }

    public void OnCollisionExit2D( Collision2D collision )
    {
        if( collision.gameObject.layer == 8 )
        {
            isOnGround = false;
        }
    }
}