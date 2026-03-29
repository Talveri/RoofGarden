
using UnityEngine;
using NUnit.Framework;
using Unity.VisualScripting;
/// <summary>
/// The InventoryHandler is a script for generating and filling Itemslots in certain panels.
/// </summary>
public class InventoryHandler : MonoBehaviour
{
    public GameObject[] GenerateInventory(Transform inventoryPanel, GameObject slotPrefab, int slotCount = 0)
    {
        // Error Handling
        Assert.That(!inventoryPanel.IsUnityNull());
        Assert.That(!slotPrefab.IsUnityNull());
        Assert.That(!slotPrefab.GetComponent<Slot>().IsUnityNull());

        if (slotCount < 0)
        {
            slotCount = 0;
            Debug.LogWarning($"slotCount is {slotCount}");
        }
        GameObject[] slots = new GameObject[slotCount];

        for (int i = 0; i < slotCount; i++)
        {
            slots[i] = Instantiate(slotPrefab, inventoryPanel);
        }
        return slots;
    }

    public bool AddItem(Transform inventoryPanel, GameObject itemPrefab)
    {
        Assert.That(!inventoryPanel.IsUnityNull());
        Assert.That(!itemPrefab.IsUnityNull());

        //look for empty slot
        foreach (Transform slotTransform in inventoryPanel)
        {
            Assert.That(!slotTransform.GetComponent<Slot>().IsUnityNull());

            Slot slot = slotTransform.GetComponent<Slot>();

            Debug.Log($"{slot} : {slot.currentItem}");

            if (slot != null && slot.currentItem == null)
            {
                GameObject newItem = Instantiate(itemPrefab, slot.transform);
                newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.currentItem = newItem;
                return true;
            }
        }
        return false;
    }

    public bool RemItem(Transform inventoryPanel, GameObject targetSlot)
    {
        Assert.That(!inventoryPanel.IsUnityNull());
        Assert.That(!targetSlot.IsUnityNull());

        

        return false;
    }
}