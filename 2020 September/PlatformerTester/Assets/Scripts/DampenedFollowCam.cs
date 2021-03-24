﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DampenedFollowCam : MonoBehaviour
{
    public Transform playerTransform;
    public float damping = 0.05f;

    private Vector3 velocity;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if( playerTransform != null )
        {
            Vector3 targetPosition = playerTransform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
        }
    }
}
