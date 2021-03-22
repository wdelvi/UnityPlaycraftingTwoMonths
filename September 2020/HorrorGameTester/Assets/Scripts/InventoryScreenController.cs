using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryOption
{
    public string optionName;
    public CollectibleType collectibleType;
    public Sprite optionSprite;
}

public class InventoryScreenController : MonoBehaviour
{
    public List<InventoryOption> inventoryOptions;
    public GameObject inventoryScreenParent;
    public Collector playerCollector;
    public Transform gridParent;
    public GameObject inventoryPrefab;

    private List<GameObject> spawnedInventoryItems;

    // Start is called before the first frame update
    void Start()
    {
        spawnedInventoryItems = new List<GameObject>();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if( inventoryScreenParent.activeSelf == true )
            {
                HideInventoryScreen();
            }
            else
            {
                ShowInventoryScreen();
            }
        }
    }

    public void ShowInventoryScreen()
    {
        inventoryScreenParent.SetActive(true);
    }

    public void HideInventoryScreen()
    {
        inventoryScreenParent.SetActive(false);
    }

    public void RefreshInventory(List<CollectibleType> collectedCollectibles)
    {
        foreach(GameObject inventoryObject in spawnedInventoryItems)
        {
            Destroy(inventoryObject);
        }

        spawnedInventoryItems = new List<GameObject>();

        if (playerCollector == null)
        {
            return;
        }

        foreach(CollectibleType collectible in playerCollector.collectedCollectibles)
        {
            foreach(InventoryOption inventoryOption in inventoryOptions)
            {
                if(inventoryOption.collectibleType == collectible)
                {
                    SpawnInventoryOption(inventoryOption);
                }
            }
        }
    }

    private void SpawnInventoryOption(InventoryOption inventoryOption)
    {
        GameObject newInventoryObject = Instantiate(inventoryPrefab) as GameObject;
        newInventoryObject.transform.parent = gridParent;
        newInventoryObject.GetComponentInChildren<InventoryItemController>().Setup(inventoryOption, this);
        spawnedInventoryItems.Add(newInventoryObject);
    }

    public void InventoryItemPressed( CollectibleType collectibleType )
    {
        if(playerCollector == null)
        {
            return;
        }

        playerCollector.RemoveCollectible(collectibleType);
        RefreshInventory(playerCollector.collectedCollectibles);
    }
}
