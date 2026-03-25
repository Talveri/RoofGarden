using RoofGardenGame.Models;
using UnityEngine;

/// <summary>
/// The Watering can should activate the watering function of the Field script
/// </summary>

public class WateringCan : MonoBehaviour, ITool
{
    private bool watering;

    public void UseToolStart()
    {
        Debug.Log("Water start");
        watering = true;
        // start watering
    }
    public void UseToolHold()
    {
        
        if(!watering) return;

        Debug.Log("Water...");
        Field field = FieldSelector.Instance.currentField;
        if(field != null)
        {
            field.Irrigate();
        }
    }

    public void UseToolRelease()
    {
        Debug.Log("Water stop");
        watering = false;
        // stop watering
    }


}