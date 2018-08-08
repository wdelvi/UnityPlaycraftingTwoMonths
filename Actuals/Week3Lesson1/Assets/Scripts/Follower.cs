using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour 
{
    public Transform target;
    public bool followX;
    public bool followY;
	
	// Update is called once per frame
	void Update () 
    {
        if( target == null )
        {
            return;
        }

        float newX = transform.position.x;
        float newY = transform.position.y;

        if( followX )
        {
            newX = target.position.x;
        }

        if( followY )
        {
            newY = target.position.y;
        }

        transform.position = new Vector3( newX, newY, transform.position.z );
	}
}
