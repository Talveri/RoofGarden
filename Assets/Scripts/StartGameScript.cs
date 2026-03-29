using System.Collections;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform cameraStartGamePosition;
    public Transform cameraInitialPosition;
    public Camera mainCamera;
    public ScreenFader fader;
    public float fadeOutTime = 0.5f;
    public GameObject StartPage;

    public GameObject[] setActive;

    void Awake()
    {
        foreach (GameObject gameObject in setActive)
        {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    public void Start()
    {
        mainCamera.transform.position = cameraInitialPosition.position;
        InputMapManager.setToUI();


    }

    public void ButtonStartGame()
    {
        fader.fadeOutTime = fadeOutTime;
        StartCoroutine(StartGame());

    }
    public IEnumerator StartGame()
    {
        yield return StartCoroutine(fader.FadeOut());
        mainCamera.transform.position = cameraStartGamePosition.position;
        StartPage.SetActive(false);
        HotbarController.activeHotbar(true);
        yield return StartCoroutine(fader.FadeIn());
        fader.fadeOutTime = 0.01f;
        InputMapManager.setToPlayer();

    }


}
