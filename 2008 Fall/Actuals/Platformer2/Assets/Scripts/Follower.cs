using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour 
{
    public Transform target;
    public float damping = 0.05f;

    private Vector3 velocity;
    private Vector3 offset;

	// Use this for initialization
	void Start () 
    {
		if( target != null )
        {
            offset = transform.position - target.transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if( target != null )
        {
            Vector3 targetPosition = target.transform.position + offset;
            targetPosition.z = transform.position.z;

            transform.position = Vector3.SmoothDamp( transform.position, targetPosition, ref velocity, damping );
        }
	}
}
