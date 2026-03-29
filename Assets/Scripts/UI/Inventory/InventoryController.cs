using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; private set; }
    public InventoryHandler inventoryHandler;
    public Transform inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount;
    public GameObject[] itemPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogError($"An Instance of this GameObject already exist. \nDeleting GameObject {gameObject.name}");
            Destroy(gameObject);
        }

        Assert.That(!inventoryPanel.IsUnityNull());
        Assert.That(!slotPrefab.IsUnityNull());
        Assert.That(slotCount > 0);
        Assert.That(!itemPrefabs.IsUnityNull());
    }

    // Generates Slots in the player inventory
    void Start()
    {
        inventoryHandler.GenerateInventory(inventoryPanel, slotPrefab, slotCount);

        for (int i = 0; i < itemPrefabs.Length; i++)
        {
            inventoryHandler.AddItem(inventoryPanel, itemPrefabs[i]);
        }
    }

    public bool AddItem(GameObject itemPrefab)
    {
        if (inventoryHandler.AddItem(inventoryPanel, itemPrefab))
            return true;
        Debug.Log("Inventory Full");
        return false;
    }

    public bool RemItem(GameObject targetSlot)
    {

        return false;
    }
}
