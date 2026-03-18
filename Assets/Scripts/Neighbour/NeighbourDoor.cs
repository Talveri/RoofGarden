using System;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.InputSystem;

public class NeighbourDoor : MonoBehaviour
{

    public NeighbourData neighbourData;
    public static event Action<NeighbourData> onDoorInteracted;
    public string tooltipText = "Knock [E]";

    public void Interact()
    {
        onDoorInteracted?.Invoke(neighbourData);
    }

    // TEST CODE DELETE LATER 
    [SerializeField] bool playerInside;
    public Dialogue dialogue;
    //
    Tooltip tooltip;

    void Awake()
    {
        tooltip = GetComponentInChildren<Tooltip>();
        tooltip.UpdateText(tooltipText);
    }



    void Update()
    {
        if (playerInside && Keyboard.current.eKey.wasPressedThisFrame && !dialogue.inDialogue)
        {
            tooltip.hideTooltip();
            dialogue.StartDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        tooltip.showTooltip();

        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        tooltip.hideTooltip();

        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
    //
}
