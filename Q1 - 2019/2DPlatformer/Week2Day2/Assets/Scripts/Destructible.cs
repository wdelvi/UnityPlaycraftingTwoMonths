using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour 
{
    public int maximumHitPoints = 3;

    private int hitPoints;

	// Use this for initialization
	void Start () 
    {
        hitPoints = maximumHitPoints;
	}

    public void TakeDamage( int damageAmount )
    {
        ModifyHitPoints(-damageAmount);
    }

    public void Heal( int healAmount )
    {
        ModifyHitPoints(healAmount);
    }
	
    private void ModifyHitPoints( int modAmount )
    {
        hitPoints += modAmount;
        
        hitPoints = Mathf.Min(maximumHitPoints, hitPoints);

        Debug.Log(hitPoints);

        if( hitPoints <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }
}
