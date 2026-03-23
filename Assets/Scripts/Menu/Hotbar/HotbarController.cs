
using UnityEngine;
using UnityEngine.InputSystem;

public class HotbarController : MonoBehaviour
{
    public GameObject hotbarPanel;
    public GameObject slotPrefab;
    public int slotCount = 8;
    //private ItemDictionary itemDictionary;
    private Key[] hotbarKeys;

    void Awake()
    {
        //itemDictionary = FindAnyObjectByType<ItemDictionary>();
        hotbarKeys = new Key[slotCount];

        for (int i = 0; i < slotCount; i++)
        {
            Slot slot = Instantiate(slotPrefab, hotbarPanel.transform).GetComponent<Slot>();
            //Keys form 0 to i;
            hotbarKeys[i] = i < 9 ? (Key)((int)Key.Digit1 + i) : Key.Digit0;
        }
    }

    void UseItemInSlot(int index)
    {
        Slot slot = hotbarPanel.transform.GetChild(index).GetComponent<Slot>();
        if (slot.currentItem != null)
        {
            Item item = slot.currentItem.GetComponent<Item>();
            item.UseItem();
        }
    }
}
