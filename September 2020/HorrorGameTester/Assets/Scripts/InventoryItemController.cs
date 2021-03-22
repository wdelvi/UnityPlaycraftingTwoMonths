using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public Text nameText;
    public Image image;

    private CollectibleType collectibleType;
    private InventoryScreenController inventoryScreenController;

    public void Setup(InventoryOption inventoryOption, InventoryScreenController newInventoryScreenController )
    {
        nameText.text = inventoryOption.optionName;
        image.sprite = inventoryOption.optionSprite;
        collectibleType = inventoryOption.collectibleType;
        inventoryScreenController = newInventoryScreenController;
    }

    public void InventoryItemPressed()
    {
        inventoryScreenController.InventoryItemPressed(collectibleType);
    }
}
