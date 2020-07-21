using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class RotateTowardsMouse : MonoBehaviour
{
    private Rotator rotator;

    void Start()
    {
        rotator = gameObject.GetComponent<Rotator>();
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.y));
        Vector3 forward = mouseWorld - transform.position;

        rotator.RotateTowardsDirection(forward);
    }
}
