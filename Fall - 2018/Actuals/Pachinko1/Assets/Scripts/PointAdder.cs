using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAdder : MonoBehaviour
{
    public int pointsToAdd;

    public void OnTriggerEnter2D( Collider2D collision )
    {
        Debug.Log( "You scored " + pointsToAdd + " points!" );
    }
}