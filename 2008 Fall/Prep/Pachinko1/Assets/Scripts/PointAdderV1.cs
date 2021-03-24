using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAdderV1 : MonoBehaviour 
{
    public int pointsToAdd;

    public void OnTriggerEnter2D( Collider2D collider )
    {
        Debug.Log( "You scored " + pointsToAdd + " points!");
    }
}
