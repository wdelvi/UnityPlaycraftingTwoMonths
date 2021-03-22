using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerNPCController : NPCController 
{
    public Transform target;
    public float maxSeeDistance = 10f;

    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( transform.position, maxSeeDistance );
    }
	
	// Update is called once per frame
	public override void Update () 
    {
        if( target )
        {
            SetMoveToPoint(target.position);
        }

        if( IsWithinDistance( maxSeeDistance ) )
        {
            if(animator)
            {
                animator.SetInteger("moving", 1);
            }

            ContinueMoving();

            base.Update();
        }
        else
        {
            if (animator)
            {
                animator.SetInteger("moving", 0);
            }

            StopMoving();
        }
	}
}
