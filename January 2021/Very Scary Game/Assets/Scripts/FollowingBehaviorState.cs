using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBehaviorState : BehaviorState
{
    public Transform followedTransform;

    public override void Tick()
    {
        base.Tick();

        if( followedTransform != null )
        {
            MoveTowardsPosition(followedTransform.position);
        }
    }

    public override void OnExitState()
    {
        base.OnExitState();

        Debug.Log("FollowingBehaviorState has been exited");
    }
}
