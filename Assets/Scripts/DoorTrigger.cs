using UnityEngine;
using UnityEngine.InputSystem;

public class DoorTrigger : MonoBehaviour
{
    bool playerInside = false;
    public Transform exitPosition;
    public Transform cameraPosition;
    private Transform player;
    public Camera mainCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Adds the z value to the cameraPosition from the main Camera
        cameraPosition.position = new Vector3(cameraPosition.position.x,
                                              cameraPosition.position.y,
                                              mainCamera.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside && Keyboard.current.eKey.wasPressedThisFrame)
        {
            MovePlayer();
        }
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
            playerInside = true;
            player = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            player = null;
        }
    }
}
