using TMPro;
using UnityEngine;

public class ShopSlot : MonoBehaviour
{
    public GameObject currentItem;
    private Item itemProperties;
    public int itemPrice;
    public TMP_Text priceText;
    public bool isShopSlot = true; // In shop menu, true = shop side , false = player side


    void Awake()
    {
        if (!priceText)
        {
            priceText = transform.Find("PriceText").GetComponent<TMP_Text>();
        }
    }

    void Start()
    {
        itemProperties = GetComponentInChildren<Item>();
        if(itemProperties != null)
        {
            itemProperties.isShopItem = true;
        }
    }


    public void UpdatePriceDisplay()
    {
        if (priceText && currentItem)
        {
            priceText.text = itemPrice.ToString();
        }
    }

}