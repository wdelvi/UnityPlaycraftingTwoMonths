using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour 
{
    public float jumpAmount = 5f;

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, jumpAmount);
    }
}
