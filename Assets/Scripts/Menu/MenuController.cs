using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{

    public GameObject menuCanvas;
    public bool inventoryOpen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuCanvas.gameObject.SetActive(false);
    }

    public void openInventory(InputAction.CallbackContext context)
    {
        Debug.Log("Open Inventory");
        if(!context.performed) return;
        ToggleInventory();
    }

    public void ToggleInventory()
    {
        menuCanvas.gameObject.SetActive(!menuCanvas.activeSelf);
        inventoryOpen = menuCanvas.activeSelf;

        if(inventoryOpen == true)
            InputMapManager.setToUI();
        else
            InputMapManager.setToPlayer();
    } 
}
