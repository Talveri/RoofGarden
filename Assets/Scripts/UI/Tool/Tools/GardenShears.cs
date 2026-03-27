using RoofGardenGame.Models;
using UnityEngine;

public class GardenShears : MonoBehaviour, ITool
{
    public void UseToolStart(Field field)
    {
        if (field != null)
        {
            // Use Tool

        }
        else
        {
            PlayerMessage.Instance.MessageTooltip("There is no plant to remove.");
        }
    }

    public void UseToolHold(Field field) { }

    public void UseToolRelease(Field field) { }
}