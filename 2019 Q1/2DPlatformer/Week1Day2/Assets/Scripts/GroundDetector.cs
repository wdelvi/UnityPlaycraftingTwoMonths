using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour 
{

    public bool isOnGround;

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platforms")
        {
            isOnGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platforms")
        {
            isOnGround = false;
        }
    }
}
