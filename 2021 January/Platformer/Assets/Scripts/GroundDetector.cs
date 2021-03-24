﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool onGround = false;

    public void OnCollisionStay2D(Collision2D collision)
    {
        onGround = true;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }
}
