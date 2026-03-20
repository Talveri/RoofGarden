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
    bool playerInside = false;
    public Transform exitPosition;
    public Transform cameraPosition;
    private Transform player;
    public Camera mainCamera;
    public ScreenFader fader;
    private Tooltip tooltip;
    public string tooltipText = "Open (E)";

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Interact()
    {
        Debug.Log("Uses Door");
        StartCoroutine(UseDoor());
    }
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
            return;


        player.position = exitPosition.position;
        if (mainCamera != null)
        {
            mainCamera.transform.position = cameraPosition.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tooltip.showTooltip();
            playerInside = true;
            player = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tooltip.hideTooltip();
            playerInside = false;
            player = null;
        }
    }

    public void Interact<T>(T data)
    {
        throw new System.NotImplementedException();
    }
}
