using System.Collections.Generic;
using UnityEngine;

public class ShopStockController : MonoBehaviour
{
    public GameObject[] stockItems;
    public GameObject ShopSlotPrefab;
    public GameObject shopPanel;


    void Start()
    {
        foreach (GameObject item in stockItems)
        {
            if (item.GetComponent<Item>()==null) continue;
            ShopSlot slot = Instantiate(ShopSlotPrefab, shopPanel.transform).GetComponent<ShopSlot>();

            GameObject shopItem = Instantiate(item, slot.transform);

            shopItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            slot.currentItem = shopItem;
            slot.itemPrice = item.GetComponent<Item>().buyPrice;
            slot.UpdatePriceDisplay();
        }
    }

}