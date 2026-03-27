using RoofGardenGame.Enums;
using RoofGardenGame.Models;
using UnityEngine;

/// <summary>
/// The Trowel is used to till the Fields.
/// </summary>
public class Trowel : MonoBehaviour, ITool
{
    AudioSource tillSound;

    void Awake()
    {
        tillSound = GetComponent<AudioSource>();
    }
    public void UseToolStart(Field field)
    {
       /// The Player gets informed why this tool can't be used
        if (field.fieldState == FieldState.Tilled)
        {
            PlayerMessage.Instance.MessageTooltip("Ready to Plant");
            return;
        }
        if (field.fieldState != FieldState.Raw)
        {
            PlayerMessage.Instance.MessageTooltip("I need to remove the plant first.");
            return;
        }

        tillSound.Play();
        field.TillField();
    }
    /// To keep ITool Modular these Functions are implemented, but not used
    public void UseToolHold(Field field) { }
    public void UseToolRelease(Field field) { }


}