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
        if (field != null)
        {
            // Use Tool
            
            return;
        }
        else
        {
            PlayerMessage.Instance.MessageTooltip("I need Fertilizer.");
            return;
        }
    }

    public void UseToolHold(Field field) { }
    public void UseToolRelease(Field field) { }


}