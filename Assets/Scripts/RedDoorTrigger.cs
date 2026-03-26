using System.Collections;
using UnityEngine;

public class RedDoorTrigger : MonoBehaviour, IInteractable
{
    Transform MenuCameraPosition;
    ScreenFader fader;

    MenuController RedDoorMenu;

    Camera mainCamera;
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

}
