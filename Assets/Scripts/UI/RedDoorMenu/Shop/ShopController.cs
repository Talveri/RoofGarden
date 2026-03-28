
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public static ShopController Instance;

    [Header("UI")]
    public GameObject shopPanel;
    public Transform shopInventory, playerInventoryGrid;
    public GameObject shopSlotPrefab;
    public TMP_Text playerMoneyText;

    private ItemDictionary itemDictionary;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogError($"An Instance of this GameObject already exist. \nDeleting GameObject {gameObject.name}");
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemDictionary = FindAnyObjectByType<ItemDictionary>();
        shopPanel.SetActive(false);
        if (CurrencyController.Instance != null)
        {
            CurrencyController.Instance.onMoneyChanged += UpdateMoneyDisplay;
            UpdateMoneyDisplay(CurrencyController.Instance.getMoney());
        }
    }

    private void UpdateMoneyDisplay(int amount)
    {
        if (playerMoneyText != null)
        {
            playerMoneyText.text = amount.ToString();
        }
    }

    public void RefreshPlayerInventoryDisplay()
    {
        PlayerStockController.Instance.RefreshPlayerInventoryDisplay();
    }

    // Makes money flash red
    public IEnumerator FlashText(float flashDuration = 0.2f)
    {
        Color originalColor = playerMoneyText.color;

        playerMoneyText.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        playerMoneyText.color = originalColor;
    }


}
