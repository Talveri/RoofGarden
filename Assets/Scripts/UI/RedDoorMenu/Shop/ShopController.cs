
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public static ShopController Instance;

    [Header("UI")]
    public GameObject shopPanel;
    public Transform shopInventory, playerInventoryGrid;
    public GameObject shopSlotPrefab;
    public TMP_Text playerMoneyText, shopTitleText;

    private ItemDictionary itemDictionary;

    void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemDictionary = FindAnyObjectByType<ItemDictionary>();
        shopPanel.SetActive(false);
        if(CurrencyController.Instance != null)
        {
            CurrencyController.Instance.onMoneyChanged += UpdateMoneyDisplay;
            UpdateMoneyDisplay(CurrencyController.Instance.getMoney());
        }
    }

    private void UpdateMoneyDisplay(int amount)
    {
        if(playerMoneyText != null)
        {
            playerMoneyText.text = amount.ToString();
        }
    }

}
