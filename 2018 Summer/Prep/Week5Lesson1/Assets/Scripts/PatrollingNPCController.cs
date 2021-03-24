using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingNPCController : NPCController 
{
    public List<Vector3> patrolPoints;

    public float minPauseTime = 3f;
    public float maxPauseTime = 8f;

    private int _moveToIndex;
    private float _pauseTimer;
    private float _timeToPause;

    public void Start()
    {
        _moveToIndex = 0;
        _pauseTimer = 0f;
        _timeToPause = Random.Range( minPauseTime, maxPauseTime );

        if ( patrolPoints.Count > 0 )
        {
            currentMoveToPoint = patrolPoints[ 0 ];
        }
    }

    public override void Update()
    {
        if( GetReachedMoveTo() )
        {
            _pauseTimer += Time.deltaTime;

            if ( _pauseTimer >= _timeToPause )
            {
                IncrementMoveToPoint();
            }
        }

        base.Update();
    }

    private void IncrementMoveToPoint()
    {
        if( patrolPoints.Count <= 0 )
        {
            return;
        }

        _pauseTimer = 0f;
        _timeToPause = Random.Range( minPauseTime, maxPauseTime );

        _moveToIndex++;

        if( _moveToIndex >= patrolPoints.Count )
        {
            _moveToIndex = 0;
        }

        currentMoveToPoint = patrolPoints[ _moveToIndex ];
    }
}
