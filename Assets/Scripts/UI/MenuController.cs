
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{

    public GameObject menuCanvas;
    public bool menuOpen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        menuCanvas.gameObject.SetActive(false);
    }

    public void openMenu(InputAction.CallbackContext context)
    {
        if(!context.performed) return;
        ToggleMenu();
    }

    public void ToggleMenu()
    {
        menuCanvas.gameObject.SetActive(!menuCanvas.activeSelf);
        menuOpen = menuCanvas.activeSelf;

        if(menuOpen == true)
            InputMapManager.setToUI();
        else
            InputMapManager.setToPlayer();
    } 
}
