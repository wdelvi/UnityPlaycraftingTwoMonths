using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour 
{
    public Transform target;
    public bool followX;
    public bool followY;

	void Update () 
    {
        if( target != null )
        {
            float newX = transform.position.x;
            float newY = transform.position.y;

            if( followX )
            {
                newX = target.transform.position.x;
            }

            if ( followY )
            {
                newY = target.transform.position.y;
            }

            transform.position = new Vector3( newX, newY, transform.position.z );               
        }
	}
}
