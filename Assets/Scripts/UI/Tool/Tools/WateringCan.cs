using RoofGardenGame.Models;
using UnityEngine;

/// <summary>
/// The Watering can should activate the watering function of the Field script
/// </summary>

public class WateringCan : MonoBehaviour, ITool
{
    public int WaterAmountPerInteraction = 5;
    private bool watering;

    private AudioSource wateringSound;

    void Awake()
    {
        wateringSound = GetComponent<AudioSource>();
    }
    public void UseToolStart(Field field)
    {
        watering = true;
        wateringSound.Play();
        // start watering
    }
    public void UseToolHold(Field field)
    {
        
        if(!watering) return;

        if(field != null)
        {
            field.Irrigate(WaterAmountPerInteraction);
        }
    }

    public void UseToolRelease(Field field)
    {
        watering = false;
        // stop watering
    }


}