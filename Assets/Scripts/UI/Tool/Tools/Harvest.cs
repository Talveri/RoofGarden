using RoofGardenGame.Models;
using RoofGardenGame.Enums;
using UnityEngine;

public class Harvest : MonoBehaviour, ITool
{
    /// <summary>
    /// Uses the Harvest Function of the Field Script
    /// </summary>
    public void UseToolStart(Field field)
    {

        if (field != null && field.fieldState == FieldState.Harvestable)
        {
            GameObject Vegetable = field.Harvest();
            InventoryController.Instance.AddItem(Vegetable);
            ParticleSystemManager.Instance.PlaySplash(field.gameObject.transform.position, Color.green);
        }
        else
        {
            PlayerMessage.Instance.MessageTooltip("I can't harvest that.");
        }
    }
    public void UseToolHold(Field field){}

    public void UseToolRelease(Field field){}

}

