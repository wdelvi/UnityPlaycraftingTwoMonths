using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public List<CollectibleType> collectedCollectibles;

    public void Awake()
    {
        // Awake is guarenteed to happen before start
        collectedCollectibles = new List<CollectibleType>();
    }

    public void Collect( CollectibleType collectibleType )
    {
        collectedCollectibles.Add(collectibleType);

        if (collectibleType == CollectibleType.HealthObject)
        {
            Destructible destructible = GetComponent<Destructible>();
            if (destructible)
            {
                destructible.HealDamage(1);
            }
        }
    }

    public int GetCollectibleCount(CollectibleType collectibleType)
    {
        int numOfType = 0;

        for(int i = 0; i < collectedCollectibles.Count; i++)
        {
            if( collectedCollectibles[i] == collectibleType)
            {
                numOfType++;
            }
        }

        return numOfType;
    }
}
