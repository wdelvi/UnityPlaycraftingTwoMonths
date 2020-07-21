using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.Rotate( new Vector3(0f, 1f, 0f));
    }
}
