using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingController : MonoBehaviour 
{
    public float patrolTime = 1f;
    public bool looksAhead = true;
    public float looksAheadDistance = 0.5f;

    private Mover controlledMover;
    private GroundDetector groundDetector;
    private Rigidbody2D controlledRigidbody;
    private float remainingPatrolTime;
    private float movementDirection;

	// Use this for initialization
	void Start () 
    {
        controlledMover = GetComponent<Mover>();
        groundDetector = GetComponent<GroundDetector>();
        controlledRigidbody = GetComponent<Rigidbody2D>();

        remainingPatrolTime = patrolTime;
        movementDirection = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
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

        float rayCastDistance = groundDetector.GetCollisionRadiusY() + 0.1f;

        return Physics2D.Raycast(rayCastOrigin, Vector2.down, rayCastDistance);
    }
}
