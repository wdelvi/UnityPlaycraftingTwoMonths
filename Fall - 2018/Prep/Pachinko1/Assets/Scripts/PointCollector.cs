using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollector : MonoBehaviour 
{
    private int points;

	// Use this for initialization
	void Start () 
    {
        points = 0;
    }
	
    public void AddPoints( int pointsToAdd )
    {
        points += pointsToAdd;
    }

    public int GetPoints()
    {
        return points;
    }
}
