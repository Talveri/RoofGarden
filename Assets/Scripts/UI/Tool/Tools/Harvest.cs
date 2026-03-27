using RoofGardenGame.Models;
using UnityEngine;

public class Harvest : MonoBehaviour, ITool
{
    /// <summary>
    /// Uses the Harvest Function of the Field Script
    /// </summary>
    public void UseToolStart(Field field)
    {

        if (field != null)
        {
            field.Harvest();
        }
        else
        {
            PlayerMessage.Instance.MessageTooltip("I can't harvest that.");
        }
    }
    public void UseToolHold(Field field){}

    public void UseToolRelease(Field field){}

}

