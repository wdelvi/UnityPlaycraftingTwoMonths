using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour 
{
    public float maxGrappleDistance = 5f;
    public LayerMask layerMask;

    private LineRenderer lineRenderer;
    private DistanceJoint2D distanceJoint;
    private Vector3 target;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxGrappleDistance);
    }

    // Use this for initialization
    void Start () 
    {
        lineRenderer = GetComponent<LineRenderer>();
        distanceJoint = GetComponent<DistanceJoint2D>();

        distanceJoint.enabled = false;
        lineRenderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if( Input.GetKeyDown( KeyCode.Mouse0 ) )
        {
            StartGrapple();
        }

        if( Input.GetKey( KeyCode.Mouse0 ) )
        {
            ContinueGrapple();
        }

        if( Input.GetKeyUp( KeyCode.Mouse0 ) )
        {
            EndGrapple();
        }
	}

    public void StartGrapple()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, target - transform.position, maxGrappleDistance, layerMask);

        if( raycastHit.collider )
        {
            distanceJoint.enabled = true;

            distanceJoint.distance = Vector2.Distance( transform.position, raycastHit.point );

            distanceJoint.connectedAnchor = raycastHit.point;

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, raycastHit.point);
        }
    }

    public void ContinueGrapple()
    {
        lineRenderer.SetPosition(0, transform.position);
    }

    public void EndGrapple()
    {
        distanceJoint.enabled = false;
        lineRenderer.enabled = false;
    }
}
