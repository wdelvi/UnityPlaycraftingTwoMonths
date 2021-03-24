using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public List<CollectibleType> collectedCollectibles;

    public void Collect( CollectibleType collectibleType )
    {
        collectedCollectibles.Add(collectibleType);

        //The below is not the best way to do things
        //It would be better to publically broadcast a message
        //And have other scripts listen for the type of collectible

        //Health Powerup
        if(collectibleType == CollectibleType.HealthPowerup)
        {
            Destructible destructible = GetComponent<Destructible>();
            if(destructible != null)
            {
                destructible.HealDamage(1);
            }
        }
        //Token
        else if(collectibleType == CollectibleType.Token)
        {
            Debug.Log("Picked up a coin!");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Collectible collectible = collision.GetComponent<Collectible>();

        if (collectible != null)
        {
            Collect(collectible.collectibleType);
            Destroy(collectible.gameObject);
        }
    }
}
