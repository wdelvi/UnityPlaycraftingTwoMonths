using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingBehaviorState : BehaviorState
{
    public List<Vector3> patrolPoints;

    public float pointReachedMaxDistance = 3f;
    public int numRandomPatrolPoints = 4;
    public float randomPointMaxDistance = 20f;

    private int moveToIndex;

    public void OnDrawGizmos()
    {
        foreach( Vector3 patrolPoint in patrolPoints )
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawWireSphere(patrolPoint, pointReachedMaxDistance);
        }
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        moveToIndex = 0;

        if( patrolPoints.Count <= 0 )
        {
            PickRandomPatrolPoints();
        }
    }

    public override void Tick()
    {
        base.Tick();

        Vector3 moveToPosition = patrolPoints[moveToIndex];

        MoveTowardsPoint(moveToPosition);

        if (GetIsWithinDistance(pointReachedMaxDistance, moveToPosition))
        {
            moveToIndex++;

            if( moveToIndex >= patrolPoints.Count )
            {
                moveToIndex = 0;
            }
        }
    }

    private void PickRandomPatrolPoints()
    {
        for( int i = 0; i < numRandomPatrolPoints; i++ )
        {
            Vector3 newPoint = transform.position;

            newPoint.x += Random.Range(-randomPointMaxDistance, randomPointMaxDistance);
            newPoint.z += Random.Range(-randomPointMaxDistance, randomPointMaxDistance);

            patrolPoints.Add(newPoint);
        }
    }
}
