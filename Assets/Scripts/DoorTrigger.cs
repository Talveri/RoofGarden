using System.Collections;
using Microsoft.VisualBasic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class DoorTrigger : MonoBehaviour, IInteractable
{
    public Transform exitPosition;
    public Transform cameraPosition;
    public Transform player;
    public Camera mainCamera;
    public ScreenFader fader;
    private Tooltip tooltip;
    public string tooltipText = "Open (E)";

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        tooltip = GetComponentInChildren<Tooltip>();
    }

    void Start()
    {
        // Adds the z value to the cameraPosition from the main Camera
        cameraPosition.position = new Vector3(cameraPosition.position.x,
                                              cameraPosition.position.y,
                                              mainCamera.transform.position.z);
        tooltip.UpdateText(tooltipText);
    }

    public void Interact<T>(T data)
    {
        Debug.Log("Uses Door: ", this);
        StartCoroutine(UseDoor());
    }

    private IEnumerator UseDoor()
    {
        //Fade out
        yield return StartCoroutine(fader.FadeOut());

        // Move Player
        MovePlayer();

        yield return StartCoroutine(fader.FadeIn());
    }
    private void MovePlayer()
    {
        if (player == null || exitPosition == null)
            {
            Debug.Log("No player found");
            return;
            }

        player.position = exitPosition.position;
        if (mainCamera != null)
        {
            mainCamera.transform.position = cameraPosition.position;
        }
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