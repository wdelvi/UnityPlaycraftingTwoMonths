using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour 
{
    public float stopDistance = 2.5f;
    public Vector3 currentMoveToPoint;

    protected Mover mover;
    protected NavMeshAgent navMeshAgent;
    protected bool canMove;

    public virtual void Awake()
    {
        mover = GetComponent<Mover>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        if( mover && navMeshAgent )
        {
            Debug.LogError( "NPCConroller should not have both Mover and NaveMeshAgent!" );
        }

        currentMoveToPoint = transform.position;
    }

	public virtual void Update () 
    {
		if( GetReachedMoveTo() == false )
        {
            if ( mover && canMove )
            {
                mover.AccelerateInDirection( GetDirection() );
            }
        }
	}

    public virtual void SetMoveToPoint( Vector3 moveTo )
    {
        currentMoveToPoint = moveTo;

        if( navMeshAgent )
        {
            navMeshAgent.destination = moveTo;
        }
    }

    public virtual Vector3 GetDirection()
    {
        return currentMoveToPoint - transform.position;
    }

    public virtual bool GetReachedMoveTo()
    {
        return ( GetDirection().magnitude < stopDistance );
    }

    public virtual bool IsWithinDistance( float distance )
    {
        return ( GetDirection().magnitude < distance );
    }

    public virtual void StopMoving()
    {
        canMove = false;

        if( navMeshAgent )
        {
            navMeshAgent.destination = transform.position;
        }
    }

    public virtual void ContinueMoving()
    {
        canMove = true;

        if( navMeshAgent )
        {
            navMeshAgent.destination = currentMoveToPoint;
        }
    }

}
