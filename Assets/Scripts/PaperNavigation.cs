using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PaperNavigation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private UIDocument uiDocument;
    public Camera mainCamera;
    public Transform cameraPosition;
    public Transform selfPosition;
    public ScreenFader fader;
    [SerializeField] private bool showResults = false;
    void Start()
    {
        // Set Cameraposition
        cameraPosition.position = new Vector3(cameraPosition.position.x,
                                      cameraPosition.position.y,
                                      mainCamera.transform.position.z);
        uiDocument = GetComponentInChildren<UIDocument>();
    }


    // Update is called once per frame
    void Update()
    {
        showResults = mainCamera.transform.position.x == selfPosition.position.x;

        if (showResults && Keyboard.current.eKey.wasPressedThisFrame)
            {
                StartCoroutine(nextDay());
            }
    }

    IEnumerator nextDay()
    {
        yield return StartCoroutine(fader.FadeOut());
        moveCamera();
        yield return StartCoroutine(fader.FadeIn());
    }

    void moveCamera()
    {
        showResults = false;
        if (mainCamera != null)
        {
            mainCamera.transform.position = cameraPosition.position;
        }
    }


}
