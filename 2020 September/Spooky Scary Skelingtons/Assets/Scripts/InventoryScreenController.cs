using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreenController : MonoBehaviour
{
    [System.Serializable]
    public class InventoryOption
    {
        public string optionName;
        public CollectibleType collectibleType;
        public Sprite optionSprite;
    }

    public List<InventoryOption> inventoryOptions;

    public GameObject inventoryParent;
    public Collector playerCollector;
    public GameObject inventoryItemPrefab;
    public Transform gridParent;

    private List<GameObject> spawnedInventoryItems;

    // Start is called before the first frame update
    void Start()
    {
        spawnedInventoryItems = new List<GameObject>();
        HideInventoryScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.I) )
        {
            if( inventoryParent.activeSelf == true )
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
        inventoryParent.SetActive(true);
    }

    public void HideInventoryScreen()
    {
        inventoryParent.SetActive(false);
    }

    public void InventoryItemPressed(CollectibleType collectibleType)
    {
        if(playerCollector)
        {
            playerCollector.RemoveCollectible(collectibleType);
            RefreshInventoryItems(playerCollector.collectedCollectibles);
        }
    }

    private void SpawnInventoryItem( InventoryOption inventoryOption )
    {
        GameObject newInventoryItem = Instantiate(inventoryItemPrefab) as GameObject;
        newInventoryItem.transform.SetParent(gridParent);
        newInventoryItem.GetComponent<InventoryItemController>().Setup(inventoryOption, this);
        spawnedInventoryItems.Add(newInventoryItem);
    }

    public void RefreshInventoryItems( List<CollectibleType> collectedCollectibles )
    {
        //Garbage collection. Delete old Inventory Items
        foreach(GameObject inventoryObject in spawnedInventoryItems)
        {
            Destroy(inventoryObject);
        }

        spawnedInventoryItems = new List<GameObject>();

        //null check
        if(playerCollector == null)
        {
            return;
        }

        //Spawn every item in inventory
        foreach(CollectibleType collectibleType in collectedCollectibles)
        {
            foreach(InventoryOption inventoryOption in inventoryOptions)
            {
                if(inventoryOption.collectibleType == collectibleType)
                {
                    SpawnInventoryItem(inventoryOption);
                    break;
                }
            }
        }
    }
}
