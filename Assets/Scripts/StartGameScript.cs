using System.Collections;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform cameraPosition;
    public Camera mainCamera;
    public ScreenFader fader;
    public float fadeOutTime = 0.5f;
    public GameObject StartPage;

    // Update is called once per frame

    public void ButtonStartGame()
    {
        fader.fadeOutTime = fadeOutTime;
        StartCoroutine(StartGame());

    }
    public IEnumerator StartGame()
    {
        yield return StartCoroutine(fader.FadeOut());
        mainCamera.transform.position = cameraPosition.position;
        StartPage.SetActive(false);
        HotbarController.activeHotbar(true);
        yield return StartCoroutine(fader.FadeIn());
        fader.fadeOutTime = 0.01f;

    }


}
