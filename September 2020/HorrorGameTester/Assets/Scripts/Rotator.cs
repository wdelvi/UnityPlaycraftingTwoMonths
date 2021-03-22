using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 1f;

    public bool lockX = false;
    public bool lockY = false;
    public bool lockZ = false;

    public void RotateTowardsDirection( Vector3 directionToFace )
    {
        //Normalizing sets all numbers to between 0 and 1 to keep behavior more expected
        directionToFace = Vector3.Normalize(directionToFace);

        float singleStep = rotationSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, directionToFace, singleStep, 0f);

        Quaternion newRotation = Quaternion.LookRotation(newDirection);

        if( lockX )
        {
            newRotation.x = transform.rotation.x;
        }

        if (lockY)
        {
            newRotation.y = transform.rotation.y;
        }

        if (lockZ)
        {
            newRotation.z = transform.rotation.z;
        }

        transform.rotation = newRotation;
    }
}
