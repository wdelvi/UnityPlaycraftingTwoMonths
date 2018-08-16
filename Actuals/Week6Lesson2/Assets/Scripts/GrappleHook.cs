using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    public float maxGrappleDistance = 5f;
    public LayerMask layerMask;

    private LineRenderer _lineRenderer;
    private DistanceJoint2D _distanceJoint;
    private Vector3 _target;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( transform.position, maxGrappleDistance );
    }

    // Use this for initialization
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _distanceJoint = GetComponent<DistanceJoint2D>();
        _distanceJoint.enabled = false;
        _lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Mouse0 ) )
        {
            StartGrapple();
        }

        if ( Input.GetKey( KeyCode.Mouse0 ) )
        {
            ContinueGrapple();
        }

        if ( Input.GetKeyUp( KeyCode.Mouse0 ) )
        {
            EndGrapple();
        }
    }

    private void StartGrapple()
    {
        _target = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        _target.z = transform.position.z;

        RaycastHit2D raycastHit = Physics2D.Raycast( transform.position, _target - transform.position, maxGrappleDistance, layerMask );

        if ( raycastHit.collider && raycastHit.collider.GetComponent<Rigidbody2D>() )
        {
            _distanceJoint.enabled = true;
            _distanceJoint.connectedBody = raycastHit.collider.GetComponent<Rigidbody2D>();

            _distanceJoint.distance = Vector2.Distance( transform.position, raycastHit.point );
            _distanceJoint.connectedAnchor = raycastHit.point -
                new Vector2( raycastHit.collider.transform.position.x, raycastHit.collider.transform.position.y );

            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition( 0, transform.position );
            _lineRenderer.SetPosition( 1, raycastHit.point );
        }
    }

    private void ContinueGrapple()
    {
        _lineRenderer.SetPosition( 0, transform.position );
    }

    private void EndGrapple()
    {
        _distanceJoint.enabled = false;
        _lineRenderer.enabled = false;
    }
}