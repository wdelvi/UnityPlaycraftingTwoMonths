using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExactFollowCam : MonoBehaviour
{
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = playerTransform.position;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
