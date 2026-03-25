using RoofGardenGame.Models;
using UnityEngine;


public class TestingKit : MonoBehaviour, ITool
{
    private bool active;

    public void UseToolStart()
    {
        active = true;
        Debug.Log("Using Testing Kit");

        ShowStatus();
    }

    public void UseToolHold() { }
    public void UseToolRelease() { }

    private void ShowStatus()
    {
        Field field = FieldSelector.Instance.currentField;

        if (field == null)
            return;

        StatusBarManager.Instance.UpdateBars(field);
    }


}