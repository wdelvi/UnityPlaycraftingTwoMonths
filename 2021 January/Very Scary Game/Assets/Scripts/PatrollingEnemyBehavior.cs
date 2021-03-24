using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemyBehavior : BehaviorState
{
    public List<Vector3> patrolPoints;

    public float pointReachedMaxDistance = 3f;

    private int currentPatrolPointIndex;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach(Vector3 patrolPoint in patrolPoints)
        {
            Gizmos.DrawWireSphere(patrolPoint, pointReachedMaxDistance);
        }
    }

    public override void Tick()
    {
        base.Tick();

        Vector3 currentMoveTo = patrolPoints[currentPatrolPointIndex];

        MoveTowardsPosition(currentMoveTo);

        if(GetIsWithinDistance(pointReachedMaxDistance, currentMoveTo))
        {
            currentPatrolPointIndex += 1;

            if(currentPatrolPointIndex >= patrolPoints.Count)
            {
                currentPatrolPointIndex = 0;
            }
        }
    }
}
