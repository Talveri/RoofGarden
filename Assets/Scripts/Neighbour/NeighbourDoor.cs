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
        neighbourData.ShowStats();
    }

    // TEST CODE DELETE LATER 
    bool playerInside;
    public Dialogue dialogue;
    public string[] script;
    //
    Tooltip tooltip;

    void Awake()
    {
        tooltip = GetComponentInChildren<Tooltip>();
        tooltip.UpdateText(tooltipText);
        neighbourData = GetComponentInChildren<NeighbourData>(true);
    }


    void Update()
    {
        if (playerInside && Keyboard.current.eKey.wasPressedThisFrame && !dialogue.inDialogue)
        {
            tooltip.hideTooltip();
            dialogue.UpdateText(script);
            dialogue.StartDialogue();
            neighbourData.ShowStats();
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
            neighbourData.HideStats();
        }
    }
    //
}
