using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputMapManager{
    static PlayerInput playerInput;

    public static void Initialize(PlayerInput input)
    {
        playerInput = input;
        playerInput.actions.FindActionMap("Global").Enable();
    }
    public static void setToPlayer()
    {
        playerInput.SwitchCurrentActionMap("Player");       
    }
    public static void setToUI()
    {
        playerInput.SwitchCurrentActionMap("UI");  
    }
}