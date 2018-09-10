using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour 
{
    public float destroySeconds = 3f;

    void Start () 
    {
        Destroy( gameObject, destroySeconds );
	}
}
