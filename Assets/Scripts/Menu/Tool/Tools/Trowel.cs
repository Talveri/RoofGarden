using RoofGardenGame.Models;
using UnityEngine;

/// <summary>
/// The Trowel is used to till the Fields.
/// </summary>
public class Trowel : MonoBehaviour, ITool
{
    public void UseTool()
    {
        Debug.Log("Using Trowel");

        Field field = FieldSelector.Instance.currentField;

        if(field == null)
        {
            PlayerMessage.Instance.MessageTooltip("No field selected");
            return;
        }

        field.TillField();
    }
}