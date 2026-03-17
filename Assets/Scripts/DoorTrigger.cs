using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class DoorTrigger : MonoBehaviour
{
    bool playerInside = false;
    public Transform exitPosition;
    public Transform cameraPosition;
    private Transform player;
    public Camera mainCamera;
    public ScreenFader fader;
    private Label tooltip;
    public string tooltipText = "Open (E)";

    [SerializeField] StyleLength fontSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        UIDocument ui = GetComponentInChildren<UIDocument>();
        tooltip = ui.rootVisualElement.Q<Label>("tooltip");
        tooltip.text = tooltipText;


    }

    void Start()
    {
        // Adds the z value to the cameraPosition from the main Camera
        cameraPosition.position = new Vector3(cameraPosition.position.x,
                                              cameraPosition.position.y,
                                              mainCamera.transform.position.z);
        tooltip.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside && Keyboard.current.eKey.wasPressedThisFrame)
        {
            StartCoroutine(UseDoor());
        }
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
            tooltip.style.display = DisplayStyle.Flex;
            playerInside = true;
            player = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tooltip.style.display = DisplayStyle.None;
            playerInside = false;
            player = null;
        }
    }
}
