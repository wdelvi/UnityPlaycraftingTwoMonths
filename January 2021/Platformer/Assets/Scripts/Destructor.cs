using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public int damage = 1;

    public bool destroyOnImpact = false;

    [Tooltip("Destructors do not damage Destructibles in their own faction")]
    public int faction;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destructible destructible = collision.gameObject.GetComponent<Destructible>();

        if( destructible != null )
        {
            //Do damage
            if (faction != destructible.faction)
            {
                destructible.TakeDamage(damage);

                if(destroyOnImpact)
                {
                    Destroy(gameObject, 0.1f);
                }
            }
        }
    }
}
