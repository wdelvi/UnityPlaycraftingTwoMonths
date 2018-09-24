using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAdder : MonoBehaviour
{
    public PointCollector pointCollector;
    public int pointsToAdd;

    public void OnTriggerEnter2D( Collider2D collision )
    {
        pointCollector.AddPoints( pointsToAdd );
    }
}