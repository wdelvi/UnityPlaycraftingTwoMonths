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
    protected bool canMove = true;

    public virtual void Awake()
    {
        mover = GetComponent<Mover>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        if( mover && navMeshAgent )
        {
            Debug.LogError("NPCController should not have a mover and navMeshAgent");
        }

        SetMoveToPoint(transform.position);
    }

    public virtual void Update()
    {
        if( IsWithinDistance( stopDistance ) == false && mover && canMove)
        {
            mover.AccelerateInDirection(GetDirection());
        }

        Vector3 lookAtPosition = new Vector3();

        lookAtPosition.x = currentMoveToPoint.x;
        lookAtPosition.z = currentMoveToPoint.z;
        lookAtPosition.y = transform.position.y;

        transform.LookAt(lookAtPosition);
    }

    public virtual void SetMoveToPoint( Vector3 moveTo )
    {
        currentMoveToPoint = moveTo;

        if( navMeshAgent )
        {
            navMeshAgent.destination = moveTo;
        }
    }

    public virtual bool IsWithinDistance( float distance )
    {
        return (GetDirection().magnitude < distance);
    }

    public virtual Vector3 GetDirection()
    {
        return currentMoveToPoint - transform.position;
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
