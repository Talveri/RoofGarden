using System.Collections;
using UnityEngine;

public class RedDoorMenuController : MonoBehaviour
{
    public Camera mainCamera;
    public Transform CameraDestinationOnClose;
    public MenuController menuController;
    public ScreenFader screenFader;

    public void CloseMenu()
    {
        StartCoroutine(MoveCamera());
        InputMapManager.SetGlobalActionMap(true);
    }

    public IEnumerator MoveCamera()
    {
        yield return StartCoroutine(screenFader.FadeOut());
        mainCamera.transform.position = CameraDestinationOnClose.position;
        menuController.ToggleMenu();
        yield return StartCoroutine(screenFader.FadeIn());

    }
}