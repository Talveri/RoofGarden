using System.Collections.Generic;
using UnityEngine;

public class ShopStockController : MonoBehaviour
{
    public GameObject[] stockItems;
    public GameObject ShopSlotPrefab;
    public GameObject shopDisplayItemPrefab;
    public GameObject shopPanel;


    void Start()
    {
        foreach (GameObject item in stockItems)
        {
            if (item.GetComponent<Item>()==null) continue;
            ShopSlot slot = Instantiate(ShopSlotPrefab, shopPanel.transform).GetComponent<ShopSlot>();

            GameObject shopItem = Instantiate(shopDisplayItemPrefab, slot.transform);

            
            shopItem.GetComponent<ReferenceItem>().SetReference(item);

            shopItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            slot.currentItem = shopItem;
            slot.itemPrice = item.GetComponent<Item>().buyPrice;
            slot.UpdatePriceDisplay();

            // ItemHandler
            ShopItemHandler handler = shopItem.AddComponent<ShopItemHandler>();
            
        }
    }

}