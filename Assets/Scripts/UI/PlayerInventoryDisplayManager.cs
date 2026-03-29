using UnityEngine;

public class PlayerInventoryDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerStockController playerStockController;
    void OnEnable()
    {
        if(playerStockController != null) playerStockController.RefreshPlayerInventoryDisplay();
    }
}
