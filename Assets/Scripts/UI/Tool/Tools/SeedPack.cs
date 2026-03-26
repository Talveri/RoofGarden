using RoofGardenGame.Models;
using UnityEngine;

/// <summary>
/// SeedPack has an additional Slot property to dynamically allocate plants
/// </summary>

public class SeedPack : MonoBehaviour, ITool
{
    public Plant plant;             // Plants shall be taken from the hotbar
    private Slot slot;

    /// <summary>
    /// Only PlantSeed items can be used
    /// </summary>

    void Awake()
    {
        slot = GetComponent<Slot>();
    }
    public void UseToolStart(Field field)
    {
        if (field != null)
            if (slot.currentItem.CompareTag("PlantSeed") || slot.currentItem == null)
                field.ReceivePlant(plant);
            else
            {
                PlayerMessage.Instance.MessageTooltip("I need plant seeds.");
            }
    }

    public void UseToolHold(Field field) { }
    public void UseToolRelease(Field field) { }


}