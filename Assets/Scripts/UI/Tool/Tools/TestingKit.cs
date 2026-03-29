using System;
using RoofGardenGame.Models;
using UnityEngine;


public class TestingKit : MonoBehaviour, ITool
{
    private bool active;

    [SerializeField] private UTKPanelController panel;

    void Awake()
    {
        panel = StatusBarManager.Instance.panelController;
    }
    public void UseToolStart(Field field)
    {
        active = true;
        panel.Show();
        ShowStatus();
    }

    public void UseToolHold(Field field)
    {
        if(!active) return;
        ShowStatus();
    }
    public void UseToolRelease(Field field)
    {
        active = false;
        panel.Hide();
    }

    private void ShowStatus()
    {
        Field field = FieldSelector.Instance.currentField;

        if (field == null)
            return;
        
        StatusBarManager.Instance.UpdateBars(field);
        UTKPlantTypeManager.Instance.UpdatePlantInfo(field.plant);
    }


}