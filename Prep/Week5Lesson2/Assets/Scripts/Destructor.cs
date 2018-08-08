using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public int damageAmount;

    public void OnCollisionEnter( Collision collision )
    {
        Destructible hitDestructible = collision.collider.GetComponent<Destructible>();

        if ( hitDestructible != null )
        {
            hitDestructible.TakeDamage( damageAmount );
        }
    }
}