using RoofGardenGame.Models;
using UnityEngine;

public class Harvest : MonoBehaviour, ITool
{
    /// <summary>
    /// Uses the Harvest Function of the Field Script
    /// </summary>
    public void UseToolStart()
    {
        Field field = FieldSelector.Instance.currentField;

        if (field != null)
        {
            field.Harvest();
        }
    }
    public void UseToolHold(){}

    public void UseToolRelease(){}

}

