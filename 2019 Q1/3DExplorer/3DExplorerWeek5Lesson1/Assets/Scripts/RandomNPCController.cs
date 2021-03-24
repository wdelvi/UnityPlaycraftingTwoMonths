using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNPCController : NPCController 
{
    public float newPointDistance = 3f;

    private Vector3 startPosition;

    public override void Awake()
    {
        startPosition = transform.position;

        base.Awake();
    }

    public void Start()
    {
        SetMoveToPoint(GetRandomMoveTo());
    }

    public override void Update()
    {
        if( IsWithinDistance(stopDistance) )
        {
            SetMoveToPoint(GetRandomMoveTo());
        }

        base.Update();
    }

    private Vector3 GetRandomMoveTo()
    {
        Vector3 newPosition = startPosition;

        newPosition.x += Random.Range( -newPointDistance, newPointDistance );
        newPosition.z += Random.Range( -newPointDistance, newPointDistance );

        return newPosition;
    }
}
