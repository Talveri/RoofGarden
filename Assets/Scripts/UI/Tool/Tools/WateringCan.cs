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
        watering = true;
        // start watering
    }
    public void UseToolHold()
    {
        
        if(!watering) return;

        Field field = FieldSelector.Instance.currentField;
        if(field != null)
        {
            field.Irrigate();
        }
    }

    public void UseToolRelease()
    {
        watering = false;
        // stop watering
    }


}