using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputMapManager
{
    static PlayerInput playerInput;

    public static void Initialize(PlayerInput input)
    {
        playerInput = input;
        playerInput.actions.FindActionMap("Global").Enable();
        setToPlayer();
    }
    public static void setToPlayer()
    {
        Debug.Log("Switch Map to player");
        playerInput.SwitchCurrentActionMap("Player");
    }
    public static void setToUI()
    {
        Debug.Log("Switch Map to UI");
        playerInput.SwitchCurrentActionMap("UI");
    }

    public static void SetGlobalActionMap(bool active)
    {
        if (active)
            playerInput.actions.FindActionMap("Global").Enable();
        else
            playerInput.actions.FindActionMap("Global").Disable();
    }
}