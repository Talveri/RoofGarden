using System;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.InputSystem;

public class NeighbourDoor : MonoBehaviour
{

    public NeighbourData neighbourData;
    public static event Action<NeighbourData> onDoorInteracted;

    // TEST CODE DELETE LATER 
    [SerializeField] bool playerInside;
    public Dialogue dialogue;
    //


    public void Interact()
    {
        onDoorInteracted?.Invoke(neighbourData);
    }


    // TEST CODE DELETE LATER
    void Update()
    {
        if (playerInside && Keyboard.current.eKey.wasPressedThisFrame)
        {
            dialogue.StartDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
    //
}
