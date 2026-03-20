using System;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.InputSystem;

public class NeighbourDoor : MonoBehaviour, IInteractable
{
    public NeighbourData neighbourData;
    public static event Action<NeighbourData> onDoorInteracted;
    public string tooltipText = "Knock [E]";

    public void Interact()
    {
        onDoorInteracted?.Invoke(neighbourData);
        neighbourData.ShowStats();

        // Code copied and modified from Update(), idk what you exactly planned for this implementation
        // You can remove it if you want to delegate the dialague stuff to the NeighbourUI script
        if (!dialogue.inDialogue)
        {
            tooltip.hideTooltip();
            dialogue.UpdateText(script);
            dialogue.StartDialogue();
            neighbourData.ShowStats();
        }
    }

    // TEST CODE DELETE LATER
    //bool playerInside;
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

    /*void Update()
    {
        if (playerInside && Keyboard.current.eKey.wasPressedThisFrame && !dialogue.inDialogue)
        {
            tooltip.hideTooltip();
            dialogue.UpdateText(script);
            dialogue.StartDialogue();
            neighbourData.ShowStats();
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D other)
    {
        tooltip.showTooltip();

        if (other.CompareTag("Player"))
        {
            //playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        tooltip.hideTooltip();

        if (other.CompareTag("Player"))
        {
            //playerInside = false;
            neighbourData.HideStats();
        }
    }
}
