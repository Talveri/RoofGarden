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

        if (InventoryController.Instance == null)
        {
            Debug.LogError("No Instance of InventoryController found!");
            return;
        }
        foreach (Transform child in playerInventoryGrid) Destroy(child.gameObject);

        Debug.Log(InventoryController.Instance.inventoryPanel.transform);

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
