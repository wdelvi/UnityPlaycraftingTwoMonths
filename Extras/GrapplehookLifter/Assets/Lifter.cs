using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifter : MonoBehaviour 
{
    public float maxLiftDistance = 1f;
    public LayerMask layerMask;
    public Transform holdPoint;

    private Transform _liftedTransform;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere( transform.position, maxLiftDistance );
    }

	// Update is called once per frame
	void Update () 
    {
        if( Input.GetKeyDown( KeyCode.E ) )
        {
            BeginLift();
        }

        if ( Input.GetKey( KeyCode.E ) )
        {
            ContinueLift();
        }

        if ( Input.GetKeyUp( KeyCode.E ) )
        {
            EndLift();
        }
	}

    private void BeginLift()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll( transform.position, maxLiftDistance, layerMask );

        float closestHitCollider = float.MaxValue;
        Collider2D objectToLift = null;

        foreach( Collider2D hitCollider in hitColliders )
        {
            Rigidbody2D hitRigidBody = hitCollider.GetComponent<Rigidbody2D>();

            if( hitRigidBody && hitRigidBody.bodyType == RigidbodyType2D.Dynamic )
            {
                float distanceToCollider = Vector2.Distance( transform.position, hitCollider.transform.position );

                if( distanceToCollider < closestHitCollider )
                {
                    closestHitCollider = distanceToCollider;
                    objectToLift = hitCollider;
                }
            }
        }

        if( objectToLift )
        {
            _liftedTransform = objectToLift.transform;
            objectToLift.enabled = false;
        }
    }

    private void ContinueLift()
    {
        if( _liftedTransform )
        {
            _liftedTransform.position = holdPoint.position;
        }
    }

    private void EndLift()
    {
        if ( _liftedTransform )
        {
            _liftedTransform.GetComponent<Collider2D>().enabled = true;
            _liftedTransform.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        }
        _liftedTransform = null;
    }
}
