using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool onGround = false;

    public void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }
}
