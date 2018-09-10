using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour 
{
    public float jumpImpulse = 2.5f;

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity += new Vector2( 0.0f, jumpImpulse );
    }
}
