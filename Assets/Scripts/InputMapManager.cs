using UnityEngine;
using UnityEngine.InputSystem;

public static class InputMapManager{
    public static PlayerInput playerInput;

    public static void setToPlayer()
    {
        playerInput.SwitchCurrentActionMap("Player");       
    }
    public static void setToUI()
    {
        playerInput.SwitchCurrentActionMap("UI");  
    }
}