using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBehaviorState : BehaviorState
{
    public Transform trackedTransform;

    public override void Tick()
    {
        base.Tick();

        if (trackedTransform == null)
        {
            return;
        }

        MoveTowardsPoint(trackedTransform.position);
    }

    public override void OnExitState()
    {
        Debug.Log("FollowingBehaviorState has been exited");
    }
}
