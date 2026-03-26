using System.Collections;
using UnityEngine;

public class RedDoorTrigger : MonoBehaviour, IInteractable
{
    public Transform MenuCameraPosition;
    public ScreenFader fader;
    public MenuController RedDoorMenu;
    public Camera mainCamera;
    public Tooltip tooltip;
    public string tooltipText;

    public void Start()
    {
        tooltip.UpdateText(tooltipText);
    }
    public IEnumerator LeaveMenu()
    {
        yield return StartCoroutine(fader.FadeOut());
        moveCamera();
        yield return StartCoroutine(fader.FadeIn());
    }

    void moveCamera()
    {
        if (mainCamera != null)
        {
            mainCamera.transform.position = MenuCameraPosition.position;
        }
    }

    public void Interact<T>(T data)
    {
        moveCamera();
        //Open RedDoorMenu 
        RedDoorMenu.ToggleMenu();
    }

    void OnTriggerEnter2D()
    {
        tooltip.showTooltip();
    }
    void OnTriggerExit2D()
    {
        tooltip.hideTooltip();
    }

}
