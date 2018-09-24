using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollector : MonoBehaviour 
{
    private int points;

	void Start () 
    {
        points = 0;
	}

    public void AddPoints( int pointsToAdd )
    {
        points += pointsToAdd;
        Debug.Log( "Total points: " + points );
    }

    public int GetPoints()
    {
        return points;
    }
}
