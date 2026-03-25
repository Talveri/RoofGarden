using RoofGardenGame.Models;
using UnityEngine;

/// <summary>
/// SeedPack has an additional Slot property to dynamically allocate plants
/// </summary>

public class SeedPack : MonoBehaviour, ITool
{
    public Plant plant;             // Plants shall be dynamically allocated from the inventory
    public void UseToolStart()
    {
        Field field = FieldSelector.Instance.currentField;
        if(field != null)
            field.ReceivePlant(plant);
    }
 
    public void UseToolHold(){}
    public void UseToolRelease(){}


}