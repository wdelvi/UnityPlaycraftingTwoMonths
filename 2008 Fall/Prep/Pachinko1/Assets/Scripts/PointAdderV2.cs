using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAdderV2 : MonoBehaviour 
{
    public PointCollector pointCollector;
    public int pointsToAdd;

    public void OnTriggerEnter2D( Collider2D collider )
    {
        pointCollector.AddPoints( pointsToAdd );
    }
}
