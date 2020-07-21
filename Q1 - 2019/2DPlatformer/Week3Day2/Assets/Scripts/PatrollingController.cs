using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingController : MonoBehaviour 
{
    public float patrolTime = 1f;
    public bool looksAhead = true;
    public float looksAheadDistance = 0.5f;

    public GroundDetector groundDetector;
    public LayerMask raycastLayermask;

    private Mover controlledMover;
    private Rigidbody2D controlledRigidbody;
    private float remainingPatrolTime;
    private float movementDirection;

	// Use this for initialization
	void Start () 
    {
        controlledMover = GetComponent<Mover>();
        controlledRigidbody = GetComponent<Rigidbody2D>();

        remainingPatrolTime = patrolTime;
        movementDirection = 1.0f;
	}

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(looksAheadDistance, looksAheadDistance, 0f));
    }

    // Update is called once per frame
    void Update () 
    {
        if( !MovingForwardIsSafe() )
        {
            remainingPatrolTime = 0.0f;
        }

        remainingPatrolTime -= Time.deltaTime;

        if (remainingPatrolTime > 0.0f)
        {
            controlledMover.AccelerateInDirection(new Vector2(movementDirection, 0.0f));
        }
        else if (!controlledMover.IsWalking() )
        {
            movementDirection *= -1;
            remainingPatrolTime = patrolTime;
        }
	}

    private bool MovingForwardIsSafe()
    {
        if( looksAhead == false )
        {
            return true;
        }

        if( controlledRigidbody.velocity.x < 0.1f && controlledRigidbody.velocity.x > -0.1f )
        {
            return true;
        }

        float directionNormal = controlledRigidbody.velocity.x / Mathf.Abs(controlledRigidbody.velocity.x);

        Vector2 rayCastOrigin = (Vector2)(transform.position + looksAheadDistance * transform.right * directionNormal) + groundDetector.colliderCenter;

        float rayCastDistance = GetRayCastDistance();
        
        return Physics2D.Raycast(rayCastOrigin, Vector2.down, rayCastDistance, raycastLayermask);
    }

    private float GetRayCastDistance()
    {
        return groundDetector.GetCollisionRadiusY() + 0.1f;
    }
}
