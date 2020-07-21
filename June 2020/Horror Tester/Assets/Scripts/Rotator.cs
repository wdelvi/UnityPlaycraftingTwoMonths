using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 1f;

    public bool lockX = false;
    public bool lockY = false;
    public bool lockZ = false;

    public void RotateTowardsDirection(Vector3 direction)
    {
        direction = Vector3.Normalize(direction);

        //Normalize the speed of our rotation betwwen 0 and 1 to smooth out our lookin
        float rotationSpeedMod = Vector3.Angle(transform.forward, direction) / 180f;

        float singleStep = rotationSpeed * rotationSpeedMod * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, singleStep, 0.0f);

        Quaternion newRotation = Quaternion.LookRotation(newDirection);

        if (lockX)
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
