using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExactFollowCam : MonoBehaviour
{
    public Transform toFollow;

    // Update is called once per frame
    void Update()
    {
        if (toFollow != null)
        {
            Vector3 newPosition = toFollow.position;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
    }
}
