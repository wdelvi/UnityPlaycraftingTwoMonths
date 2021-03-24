using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour 
{
    public int maximumHitPoints = 3;

    [HideInInspector]
    public int hitPoints;

	// Use this for initialization
	void Start () 
    {
        hitPoints = maximumHitPoints;
	}

    public void TakeDamage( int amount )
    {
        ModifyHitPoints( -amount );
    }

    public void RecoverHitPoints( int amount )
    {
        ModifyHitPoints( amount );
    }

    private void ModifyHitPoints( int amount )
    {
        hitPoints += amount;

        hitPoints = Mathf.Min( hitPoints, maximumHitPoints );

        Debug.Log( "Hit Points: " + hitPoints );

        if( hitPoints <= 0 )
        {
            Die();
        }
    }
	
    private void Die()
    {
        Destroy( gameObject );
    }
}
