using UnityEditor;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount;
    public GameObject[] itemPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < slotCount; i++)
        {
            Slot slot = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<Slot>();
            if (i < itemPrefabs.Length && itemPrefabs[i] != null)
            {
                Debug.Log($"Prefab at index {i} is: {itemPrefabs[i]} (Is prefab: {PrefabUtility.IsPartOfPrefabAsset(itemPrefabs[i])})");
                GameObject item = Instantiate(itemPrefabs[i], slot.transform);
                Debug.Log(item.GetComponent<RectTransform>());

                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.currentItem = item;
            }
        }
    }
}
