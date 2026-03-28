using RoofGardenGame;
using UnityEditor;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;
    public GameObject inventoryPanel;
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
    }

    // Generates Slots in the player inventory
    void Start()
    {
        InventoryHandler.Instance.GenerateInventory(inventoryPanel, slotPrefab, slotCount);

        for(int i = 0; i < itemPrefabs.Length; i++)
        {
            InventoryHandler.Instance.AddItem(inventoryPanel,itemPrefabs[i]);
        }

    }

    public bool AddItem(GameObject itemPrefab)
    {
        if (InventoryHandler.Instance.AddItem(inventoryPanel, itemPrefab))
            return true;
        Debug.Log("Inventory Full");
        return false;
    }
}
