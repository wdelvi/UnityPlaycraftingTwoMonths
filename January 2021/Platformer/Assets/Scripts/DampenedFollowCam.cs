using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DampenedFollowCam : MonoBehaviour
{
    public Transform toFollow;
    public float damping = 0.05f;

    private Vector3 velocity;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //This means that whatever the relationship is between the camera and followedobject
        //At the start of the game is what it's going to keep
        offset = transform.position - toFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        if( toFollow != null )
        {
            Vector3 targetPosition = toFollow.position + offset;

            transform.position =
                Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
        }
    }
}
