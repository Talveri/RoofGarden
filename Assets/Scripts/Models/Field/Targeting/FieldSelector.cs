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
    public Field currentField;
    public static FieldSelector Instance {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    public void SetField(Field field)
    {
        currentField = field;
    }

    public void ClearField()
    {
        currentField = null;
    }
    public void MoveToField(Field field)
    {
        transform.position = field.transform.position;
        Instance.SetField(field);      
    }
    public void Active(bool active)
    {
        gameObject.SetActive(active);
    }
}
