using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour 
{
    public float maxGrappleDistance = 10f;
    public LayerMask layerMask;

    private DistanceJoint2D _distanceJoint;
    private Vector3 _targetPosition;
    private RaycastHit2D _raycastHit;
    private LineRenderer _line;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( transform.position, maxGrappleDistance );

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, _targetPosition);
    }

    public void Start () 
    {
        _line = GetComponent<LineRenderer>();
        _distanceJoint = GetComponent<DistanceJoint2D>();
        _distanceJoint.enabled = false;
        _line.enabled = false;
	}
	
    public void Update () 
    {
        if( Input.GetKeyDown( KeyCode.Mouse0 ) )
        {
            StartGrapple();
        }

        if ( Input.GetKeyUp( KeyCode.Mouse0 ) )
        {
            EndGrapple();
        }

        //Part two
        if( Input.GetKey( KeyCode.Mouse0 ) )
        {
            ContinueGrapple();
        }
	}

    private void StartGrapple()
    {
        this._targetPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        this._targetPosition.z = transform.position.z;

        _raycastHit = Physics2D.Raycast( transform.position, _targetPosition - transform.position, maxGrappleDistance, layerMask );

        if (_raycastHit.collider)
        {
            Debug.Log("HEY! " + _raycastHit.collider + " " + _raycastHit.collider.GetComponent<Rigidbody2D>());
        }

        if ( _raycastHit.collider && _raycastHit.collider.GetComponent<Rigidbody2D>() )
        {
            _distanceJoint.enabled = true;
            _distanceJoint.connectedBody = _raycastHit.collider.GetComponent<Rigidbody2D>();

            //part one use _raycastHit.collider.transform.position
            _distanceJoint.distance = Vector2.Distance( transform.position, _raycastHit.point );

            //part two
            _line.enabled = true;
            _line.SetPosition( 0, transform.position );
            _line.SetPosition( 1, _raycastHit.point );

            _distanceJoint.connectedAnchor = _raycastHit.point - new Vector2( _raycastHit.collider.transform.position.x, _raycastHit.collider.transform.position.y );

            Debug.Log("Am Connected");
        }
    }

    private void EndGrapple()
    {
        _distanceJoint.enabled = false;
        _line.enabled = false;
    }

    private void ContinueGrapple()
    {
        _line.SetPosition( 0, transform.position );
    }
}
