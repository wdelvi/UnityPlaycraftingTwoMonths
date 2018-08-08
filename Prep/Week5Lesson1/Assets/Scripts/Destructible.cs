using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour 
{
    public int maximumHitPoints = 3;
    public float invincibilityTime = 1f;

    [HideInInspector]
    public int hitPoints = 3; 

    private float lastTimeHurt;
    private Animator animator;

	// Use this for initialization
	public void Start () 
    {
        animator = GetComponent<Animator>();
        hitPoints = maximumHitPoints;
	}

    public void TakeDamage( int amount )
    {
        if ( Time.time - lastTimeHurt < invincibilityTime )
        {
            return;
        }

        ModifyHitPoints( -amount );
        lastTimeHurt = Time.time;

        Debug.Log( "Hit! Hit Points Remaining: " + hitPoints );
    }

    public void RecoverHitPoints( int amount )
    {
        ModifyHitPoints( amount );
    }
	
    private void ModifyHitPoints( int amount )
    {
        hitPoints += amount;
        hitPoints = Mathf.Min( hitPoints, maximumHitPoints );

        if ( hitPoints <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy( gameObject );
    }
}
