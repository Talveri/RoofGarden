
using UnityEngine;
#if UNITY_EDITOR
using NUnit.Framework;
#endif
using Unity.VisualScripting;
/// <summary>
/// The InventoryHandler is a script for generating and filling Itemslots in certain panels.
/// </summary>
public class InventoryHandler : MonoBehaviour
{
    public GameObject[] GenerateInventory(Transform inventoryPanel, GameObject slotPrefab, int slotCount = 0)
    {
        // Error Handling


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


        //look for empty slot
        foreach (Transform slotTransform in inventoryPanel)
        {


            Slot slot = slotTransform.GetComponent<Slot>();

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

    public bool RemItem(Transform inventoryPanel, GameObject itemPrefab)
    {

        int ItemID = itemPrefab.GetComponent<Item>().ID;

        foreach (Transform slotTransform in inventoryPanel)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot == null) continue;
            if (slot.currentItem != null && slot.currentItem.GetComponent<Item>().ID == ItemID)
            {
                slot.removeCurrentItem();
                return true;
            }
        }

        return false;
    }
}