using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingNPCController : NPCController 
{
    public List<Vector3> patrolPoints;

    private int moveToIndex;

    public void Start()
    {
        moveToIndex = 0;

        if( patrolPoints.Count > 0 )
        {
            SetMoveToPoint(patrolPoints[0]);
        }
    }

    public override void Update()
    {
        if( IsWithinDistance (stopDistance) )
        {
            IncrementMoveToPoint();
        }

        base.Update();
    }

    private void IncrementMoveToPoint()
    {
        if( patrolPoints.Count == 0 )
        {
            return;
        }

        moveToIndex++;

        if( moveToIndex >= patrolPoints.Count )
        {
            moveToIndex = 0;
        }

        SetMoveToPoint(patrolPoints[moveToIndex]);
    }
}
