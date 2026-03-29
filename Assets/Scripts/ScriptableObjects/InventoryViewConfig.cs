using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventoryViewConfig")]
public class InventoryViewConfig : ScriptableObject
{
    public GameObject slotPrefab;
    public ItemDictionary itemDictionary;
}
