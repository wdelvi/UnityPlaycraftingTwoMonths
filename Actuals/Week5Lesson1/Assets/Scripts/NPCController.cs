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

	public virtual void Update () 
    {
		if( GetReachedMoveTo() == false )
        {
            mover.AccelerateInDirection( GetDirection() );
        }
	}

    public virtual void SetMoveToPoint( Vector3 moveTo )
    {
        currentMoveToPoint = moveTo;
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
