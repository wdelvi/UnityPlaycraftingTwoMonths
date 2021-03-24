using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNPCController : NPCController 
{
    public float maxMoveFromStartPosition;

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

        SetMoveToPoint( GetNewRandomMovePosition() );
    }

    public override void Update()
    {
        if ( GetReachedMoveTo() )
        {
            _pauseTimer += Time.deltaTime;

            if ( _pauseTimer >= _timeToPause )
            {
                SetMoveToPoint( GetNewRandomMovePosition() );

                _pauseTimer = 0f;
                _timeToPause = Random.Range( minPauseTime, maxPauseTime );
            }
        }

        base.Update();
    }

    private Vector3 GetNewRandomMovePosition()
    {
        Vector3 newMoveTo = _startPosition;
        newMoveTo.x += Random.Range( -maxMoveFromStartPosition, maxMoveFromStartPosition );
        newMoveTo.z += Random.Range( -maxMoveFromStartPosition, maxMoveFromStartPosition );
        return newMoveTo;

    }
}
