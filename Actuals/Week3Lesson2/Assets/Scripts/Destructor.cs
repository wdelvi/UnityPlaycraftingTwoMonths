using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour 
{
    public int damageAmount;

    public void OnCollisionEnter2D( Collision2D collision )
    {
        Destructible hitDestructible = collision.collider.GetComponent<Destructible>();

        if( hitDestructible != null )
        {
            hitDestructible.TakeDamage( damageAmount );
        }
    }
}
