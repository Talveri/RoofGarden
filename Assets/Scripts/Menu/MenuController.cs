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

    void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        menuCanvas.gameObject.SetActive(!menuCanvas.activeSelf);
        inventoryOpen = menuCanvas.activeSelf;

        if(inventoryOpen == true)
            InputMapManager.setToUI();
        else
            InputMapManager.setToPlayer();
    } 
}
