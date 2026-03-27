using RoofGardenGame.Enums;
using RoofGardenGame.Models;
using UnityEngine;

public class Fertilizer : MonoBehaviour, ITool
{
    private Slot slot;

    void Awake()
    {
        slot = GetComponent<Slot>();
    }
    public void UseToolStart(Field field)
    {
        if (field.FieldState == FieldState.Planted)
        {
            // Use Tool
            
            return;
        }
        else
        {
            PlayerMessage.Instance.MessageTooltip("There is no plant to remove.");
            return;
        }
    }

    public void UseToolHold(Field field) { }
    public void UseToolRelease(Field field) { }


}