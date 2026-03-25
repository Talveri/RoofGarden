using RoofGardenGame.Models;
using UnityEngine;

/// <summary>
/// The Watering can should activate the watering function of the Field script
/// </summary>

public class WateringCan : MonoBehaviour, ITool
{
    public void UseTool()
    {
        Debug.Log("Using Watering Can");

        Field field = FieldSelector.Instance.currentField;

        if(field == null)
        {
            PlayerMessage.Instance.MessageTooltip("No field selected");
            return;
        }

        field.Irrigate();
    }
}