using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    protected bool GetIsWithinDistance( float maxDistance, Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - transform.position;

        return (directionToTarget.magnitude <= maxDistance);
    }

    protected void MoveTowardsPosition( Vector3 moveTo )
    {
        mover.AccelerateInDirection(moveTo - transform.position);

        rotator.RotateTowardsDirection(moveTo - transform.position);
    }
}
