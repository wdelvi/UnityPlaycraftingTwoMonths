using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNPCController : NPCController 
{
    public float maxMoveFromStartPosition;

    public float newPointDistance = 3f;

    public float minPauseTime = 3f;
    public float maxPauseTime = 8f;

    private float _pauseTimer;
    private float _timeToPause;

    private Vector3 _startPosition;

    public override void Awake()
    {
        _startPosition = transform.position;

        base.Awake();
    }

    public void Start()
    {
        _pauseTimer = 0f;
        _timeToPause = Random.Range( minPauseTime, maxPauseTime );

        SetMoveToPoint( GetRandomMoveToPosition() );
    }

    public override void Update()
    {
        if( IsWithinDistance( newPointDistance ) )
        {
            _pauseTimer += Time.deltaTime;

            if( _pauseTimer >= _timeToPause )
            {
                SetMoveToPoint( GetRandomMoveToPosition() );

                _pauseTimer = 0f;
                _timeToPause = Random.Range( minPauseTime, maxPauseTime );
            }
        }

        base.Update();
    }

    private Vector3 GetRandomMoveToPosition()
    {
        Vector3 newMoveTo = _startPosition;
        newMoveTo.x += Random.Range( -maxMoveFromStartPosition, maxMoveFromStartPosition );
        newMoveTo.z += Random.Range( -maxMoveFromStartPosition, maxMoveFromStartPosition );
        return newMoveTo;
    }
}
