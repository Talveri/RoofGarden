using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStockController : MonoBehaviour
{
    public static PlayerStockController Instance { get; private set; }
    public Transform playerInventoryGrid;
    public GameObject slotPrefab;
    public GameObject itemDictionaryGameObject;
    private ItemDictionary itemDictionary;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogError($"An Instance of this GameObject already exist. \nDeleting GameObject {gameObject.name}");
            Destroy(gameObject);
        }

        Assert.That(!itemDictionaryGameObject.IsUnityNull());
        Assert.That(!slotPrefab.IsUnityNull());
        Assert.That(!playerInventoryGrid.IsUnityNull());

        itemDictionary = itemDictionaryGameObject.GetComponent<ItemDictionary>();
    }


    public void RefreshPlayerInventoryDisplay()
    {
        if (InventoryController.Instance == null)
        {
            Debug.LogError("No Instance of InventoryController found!");
            return;
        }

        // Object specific
        foreach (Transform child in playerInventoryGrid) Destroy(child.gameObject);

        Debug.Log(InventoryController.Instance.inventoryPanel.transform);

        foreach (Transform slotTransform in InventoryController.Instance.inventoryPanel.transform)
        {
            Slot inventorySlot = slotTransform.GetComponent<Slot>();
            GameObject slotObj = Instantiate(slotPrefab, playerInventoryGrid);

            // Create Replica Display when item is on that position
            if (inventorySlot?.currentItem != null)
            {
                // Set slot item-property to item in inventory
                Item item = inventorySlot.currentItem.GetComponent<Item>();
                Assert.That(!item.IsUnityNull(), "Current Item has no Item component!");

                slotObj.GetComponent<Slot>().currentItem = inventorySlot.currentItem;

                Debug.Log(item.ID);
                GameObject itemPrefab = itemDictionary.GetItemPrefab(item.ID);
                if (itemPrefab == null) return;

                GameObject itemInstance = Instantiate(itemPrefab, slotObj.transform);
                itemInstance.GetComponent<ItemDragHandler>().enabled = false;
                itemInstance.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            }
        }
    }
}
