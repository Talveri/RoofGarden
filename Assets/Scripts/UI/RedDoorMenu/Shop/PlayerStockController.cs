using System.Collections.Generic;
using UnityEngine;

public class PlayerStockController : MonoBehaviour
{
    public Transform playerInventoryGrid;
    public GameObject shopSlotPrefab;

    void Start()
    {
        RefreshPlayerInventoryDisplay();
    }

    public void RefreshPlayerInventoryDisplay()
    {
        Debug.Log("Refreshing Player Inventory");
        if (InventoryController.Instance == null) return;
        foreach (Transform child in playerInventoryGrid) Destroy(child.gameObject);

        Debug.Log(InventoryController.Instance.inventoryPanel.transform.childCount);

        foreach (Transform slotTransform in InventoryController.Instance.inventoryPanel.transform)
        {
            Slot inventorySlot = slotTransform.GetComponent<Slot>();
            if (inventorySlot?.currentItem == null)
            {
                GameObject slotObj = Instantiate(shopSlotPrefab, playerInventoryGrid);
            }
        }
    }
}
