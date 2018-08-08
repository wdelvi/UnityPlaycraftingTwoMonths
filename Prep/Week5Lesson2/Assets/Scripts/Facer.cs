using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facer : MonoBehaviour 
{
    public Transform target;

    public void Update()
    {
        if (target)
        {
            transform.LookAt(target.position);
        }
    }
}
