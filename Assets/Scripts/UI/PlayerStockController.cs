#if UNITY_EDITOR
using NUnit.Framework;
#endif
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStockController : MonoBehaviour
{
    public ItemDictionary itemDictionary;
    public Transform playerInventoryGrid;
    public GameObject slotPrefab;

    [SerializeField] bool dragItems = false;

    void Awake()
    {
        Assert.That(!itemDictionary.IsUnityNull());
        Assert.That(!playerInventoryGrid.IsUnityNull());
        Assert.That(!slotPrefab.IsUnityNull());
        Assert.That(!slotPrefab.GetComponent<Slot>().IsUnityNull());
    }

    public void RefreshPlayerInventoryDisplay()
    {

        // Remove every slot in the inventory grid
        foreach (Transform child in playerInventoryGrid) Destroy(child.gameObject);
        
        if(InventoryController.Instance == null) return;
        foreach (Transform slotTransform in InventoryController.Instance.inventoryPanel.transform)
        {
            Slot inventorySlot = slotTransform.GetComponent<Slot>();
            GameObject slotObj = Instantiate(slotPrefab, playerInventoryGrid);

            // Put an Item in the slot
            if (inventorySlot?.currentItem != null)
            {
                // Set slot item-property to item in inventory
                Item item = inventorySlot.currentItem.GetComponent<Item>();

                slotObj.GetComponent<Slot>().currentItem = inventorySlot.currentItem;

                GameObject itemPrefab = itemDictionary.GetItemPrefab(item.ID);

                if (itemPrefab == null) return;

                GameObject itemInstance = Instantiate(itemPrefab, slotObj.transform);
                itemInstance.GetComponent<ItemDragHandler>().enabled = dragItems;
                itemInstance.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            }
        }
    }
}
