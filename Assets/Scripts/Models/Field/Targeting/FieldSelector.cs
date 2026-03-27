using RoofGardenGame.Models;
using UnityEngine;

/// <summary>
/// The Field Selector is the Overlay that shows the player which field they can currently interact with.
/// This Script is attached to the GameObject that shall act as an overlay.
/// The Field Selector knows which Field is currently selected and can share that knowledge with the tool the player uses
/// (FieldSelector.Instance.currentField)
///
/// </summary>
public class FieldSelector : MonoBehaviour
{
    public Field currentField = null;
    public static FieldSelector Instance { get; private set; }
    public SpriteRenderer selectorVisual;

    private void Awake()
    {
        Instance = this;
        selectorVisual.enabled = false;
    }

    public void SetField(Field field)
    {
        currentField = field;
        MoveToField(field);
    }

    public void ClearField()
    {
        currentField = null;
        // Move the selector to a default position (e.g. off-screen) when no field is selected to be safe
        transform.position = new Vector3(-1000, -1000, 0);
    }

    private void MoveToField(Field field)
    {
        transform.position = field.transform.position;
    }

    public void Active(bool active)
    {
        selectorVisual.enabled = active;
        if (!active)
            currentField = null;
    }
}
