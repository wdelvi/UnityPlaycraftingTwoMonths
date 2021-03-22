using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the parent state for all behavior states
//All states will inherit logic from it
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Rotator))]
public class BehaviorState : MonoBehaviour
{
    protected Mover mover;
    protected Rotator rotator;

    // Start is called before the first frame update
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
        rotator = GetComponent<Rotator>();
    }

    public virtual void Tick()
    {

    }

    public virtual void OnExitState()
    {

    }

    protected bool GetIsWithinDistance( float maxDistance, Vector3 targetPosition )
    {
        Vector3 directionToTarget = targetPosition - transform.position;

        return (directionToTarget.magnitude < maxDistance);
    }

    protected void MoveTowardsPoint(Vector3 moveTo)
    {
        if( mover == null )
        {
            Debug.Log("No Mover Found");
            return;
        }

        mover.AccelerateInDirection(moveTo - transform.position);
        rotator.RotateTowardsDirection(moveTo - transform.position);
    }
}
