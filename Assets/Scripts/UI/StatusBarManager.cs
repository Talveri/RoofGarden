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
    [SerializeField] private StatusBar nBar;
    [SerializeField] private StatusBar pBar;
    [SerializeField] private StatusBar kBar;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateBars(Field field)
    {
        waterBar.UpdateStatusBar(field.moisture);
        nBar.UpdateStatusBar(field.nitrogen);
        pBar.UpdateStatusBar(field.phosphor);
        kBar.UpdateStatusBar(field.potassium);
    }
}