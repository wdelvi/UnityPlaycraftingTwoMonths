using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerNPCController : NPCController
{
    public Transform target;
    public float maxSeeDistance = 20f;

    private Animator animator;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( transform.position, maxSeeDistance );
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Update () 
    {
        if( target )
        {
            SetMoveToPoint( target.position );
        }

        if( IsWithinDistance( maxSeeDistance ) )
        {
            animator.SetInteger( "moving", 1 );
            base.Update();
        }
        else
        {
            animator.SetInteger( "moving", 0 );
        }
	}
}
