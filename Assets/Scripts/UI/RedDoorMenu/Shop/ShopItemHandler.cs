using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItemHandler : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hovering");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            BuyItem();
        }
    }

    private void BuyItem()
    {
        Item item = GetComponent<Item>();
        ShopSlot slot = GetComponentInParent<ShopSlot>();
        if (!item || !slot) return;

        if (CurrencyController.Instance.getMoney() < slot.itemPrice)
        {
            //Not enough Money
            StartCoroutine(NotEnoughMoney());
            return;
        }

        //Debug.Log(item.ID);
        GameObject itemPrefab = FindAnyObjectByType<ItemDictionary>().GetItemPrefab(item.ID);
        if (InventoryController.Instance.AddItem(itemPrefab))
        {
            Debug.Log($"Add Item {itemPrefab.name}");
            CurrencyController.Instance.SpendMoney(slot.itemPrice);
            ShopController.Instance.RefreshPlayerInventoryDisplay();
        }
        else
        {
            Debug.Log("Inventory full!");
        }
    }

    private IEnumerator NotEnoughMoney()
    {
       yield return StartCoroutine(ShopController.Instance.FlashText()); 
    }
}