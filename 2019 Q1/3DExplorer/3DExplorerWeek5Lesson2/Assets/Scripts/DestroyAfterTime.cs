﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour 
{
    public float destroyTime = 3f;

	// Use this for initialization
	void Start () 
    {
        Destroy(this.gameObject, destroyTime);
	}
}
