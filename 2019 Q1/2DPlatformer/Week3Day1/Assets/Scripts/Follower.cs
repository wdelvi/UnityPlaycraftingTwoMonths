using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour 
{
    public Transform target;
    public float damping = 0.5f;

    public Vector3 velocity;
    public Vector3 offset;

	// Use this for initialization
	private void Start () 
    {
        offset = transform.position - target.position;
	}

    // Update is called once per frame
    private void Update () 
    {
        if( target == null )
        {
            return;
        }

        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp( transform.position, targetPosition, ref velocity, damping );
	}
}
