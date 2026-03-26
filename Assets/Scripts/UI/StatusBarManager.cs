using RoofGardenGame.Enums;
using RoofGardenGame.Models;
using UnityEngine;
/// The StatusBar Manager is for externally changing and Updating the status
/// of a field via visual stats.

public class StatusBarManager : MonoBehaviour
{
    public static StatusBarManager Instance {get; private set;}
    public UTKPanelController panelController;

    [SerializeField] private StatusBar waterBar;
    [SerializeField] private StatusBar NBar;
    [SerializeField] private StatusBar PBar;
    [SerializeField] private StatusBar KBar;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateBars(Field field)
    {
        if(field == null) return;
        waterBar.UpdateStatusBar(field.moisture);
        NBar.UpdateStatusBar(field.nitrogen);
        PBar.UpdateStatusBar(field.phosphor);
        KBar.UpdateStatusBar(field.potassium);
    }
}