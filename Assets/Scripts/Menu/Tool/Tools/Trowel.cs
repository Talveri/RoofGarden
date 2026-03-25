using RoofGardenGame.Enums;
using RoofGardenGame.Models;
using UnityEngine;

/// <summary>
/// The Trowel is used to till the Fields.
/// </summary>
public class Trowel : MonoBehaviour, ITool
{
    public void UseToolStart()
    {
        Debug.Log("Using Trowel");

        Field field = FieldSelector.Instance.currentField;

        if (field == null)
        {
            PlayerMessage.Instance.MessageTooltip("No field selected");
            return;
        }
/// The Player gets informed why this tool can't be used
        if (field.FieldState == FieldState.Tilled)
        {
            PlayerMessage.Instance.MessageTooltip("Ready to Plant");
            return;
        }
        if (field.FieldState != FieldState.Raw)
        {
            PlayerMessage.Instance.MessageTooltip("I need to remove the plant first.");
            return;
        }

        field.TillField();
    }
    /// To keep ITool Modular these Functions are implemented, but not used
    public void UseToolHold() { }
    public void UseToolRelease() { }


}