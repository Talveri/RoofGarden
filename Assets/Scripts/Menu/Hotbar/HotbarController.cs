
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HotbarController : MonoBehaviour
{
    public GameObject hotbarPanel;
    public List<Image> ToolPrefabs;
    private int toolCount;
    //private ItemDictionary itemDictionary;
    private Key[] hotbarKeys;

    void Awake()
    {
        toolCount = ToolPrefabs.Count;
        //itemDictionary = FindAnyObjectByType<ItemDictionary>();
        hotbarKeys = new Key[toolCount];

        for (int i = 0; i < toolCount; i++)
        {
            GameObject tool = Instantiate(ToolPrefabs[i].GameObject(),hotbarPanel.transform);

            tool.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
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
