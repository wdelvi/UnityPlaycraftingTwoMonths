using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBehaviorState : BehaviorState
{
    private Vector3 moveToPosition;

    public float timeBetweenNewMoveTo = 3f;
    public float moveToMaxDistance = 10f;

    private float newMoveToTimer;

    public override void Start()
    {
        base.Start();
        PickRandomMoveTo();
    }

    public override void Tick()
    {
        base.Tick();

        newMoveToTimer += Time.deltaTime;

        if( newMoveToTimer > timeBetweenNewMoveTo)
        {
            PickRandomMoveTo();
        }

        MoveTowardsPoint(moveToPosition);
    }

    private void PickRandomMoveTo()
    {
        newMoveToTimer = 0f;

        Vector3 newMoveTo = transform.position;

        newMoveTo.x += Random.Range(-moveToMaxDistance, moveToMaxDistance);
        newMoveTo.z += Random.Range(-moveToMaxDistance, moveToMaxDistance);

        moveToPosition = newMoveTo;
    }

    public override void OnExitState()
    {
        
    }
}
