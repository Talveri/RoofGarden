using UnityEngine;

public class ShopPageManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        PlayerStockController.Instance.RefreshPlayerInventoryDisplay();
    }
}
