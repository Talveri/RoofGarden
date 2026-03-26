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
            if (slot.currentItem != null && slot.currentItem.CompareTag("Fertilizer"))
            {
                // Do nutrients
                slot.removeCurrentItem();    
            }
            else
            {
                PlayerMessage.Instance.MessageTooltip("I need fertilizer.");
            }
    }

    public void UseToolHold(Field field) { }
    public void UseToolRelease(Field field) { }


}