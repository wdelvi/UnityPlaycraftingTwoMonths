using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public List<CollectibleType> collectedCollectibles;
    public InventoryScreenController inventoryScreenController;

    public void Awake()
    {
        // Awake is guarenteed to happen before start
        collectedCollectibles = new List<CollectibleType>();
    }

    public void Collect( CollectibleType collectibleType )
    {
        collectedCollectibles.Add(collectibleType);

        if(inventoryScreenController)
        {
            inventoryScreenController.RefreshInventoryItems(collectedCollectibles);
        }
    }

    public void RemoveCollectible(CollectibleType collectibleType)
    {
        for( int i = 0; i < collectedCollectibles.Count; i++ )
        {
            if(collectedCollectibles[i] == collectibleType)
            {
                collectedCollectibles.RemoveAt(i);
                return;
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
