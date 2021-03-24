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

    public virtual void Awake()
    {
        mover = GetComponent<Mover>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        if( mover && navMeshAgent )
        {
            Debug.LogError("NPCController should not have both Mover and NavMeshAgent!");
        }

        currentMoveToPoint = transform.position;
    }

	public virtual void Update () 
    {
		if( GetReachedMoveTo() == false )
        {
            if( mover )
            {
                mover.AccelerateInDirection(GetDirection());   
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
}
