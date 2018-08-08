using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour 
{
    public float stopDistance = 2.5f;
    public Vector3 currentMoveToPoint;

    protected Mover mover;

    public virtual void Awake()
    {
        mover = GetComponent<Mover>();
        currentMoveToPoint = transform.position;
    }

    public virtual void Update()
    {
        if ( GetReachedMoveTo() == false )
        {
            mover.AccelerateInDirection( GetAcceleration() );
        }
    }

    public virtual void SetMoveToPoint( Vector3 moveTo )
    {
        currentMoveToPoint = moveTo;
    }

    public virtual bool GetReachedMoveTo()
    {
        return ( GetAcceleration().magnitude < stopDistance );
    }

    protected virtual Vector3 GetAcceleration()
    {
        return currentMoveToPoint - transform.position;
    }
}
