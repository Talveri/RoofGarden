using System;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.InputSystem;

public class NeighbourDoor : MonoBehaviour, IInteractable
{
    public NeighbourData neighbourData;
    public SpriteRenderer MoodDisplay;
    public NeighbourDialogue neighbourDialogue;
    public static event Action<NeighbourData> onDoorInteracted;
    public string tooltipText = "Knock [E]";
    public void Interact<T>(T data)
    {
        onDoorInteracted?.Invoke(neighbourData);
        MoodDisplay.sprite = neighbourData.GetMoodImage();
        MoodDisplay.gameObject.SetActive(true);
        // Code copied and modified from Update(), idk what you exactly planned for this implementation
        // You can remove it if you want to delegate the dialague stuff to the NeighbourUI script
        if (!dialogue.inDialogue)
        {
            tooltip.hideTooltip();
            dialogue.UpdateText(scriptLines);
            dialogue.StartDialogue();
            MoodDisplay.sprite = neighbourData.GetMoodImage();
        }
        
    }

    // TEST CODE DELETE LATER
    //bool playerInside;
    public Dialogue dialogue;
    private string[] scriptLines;

    //
    Tooltip tooltip;

    void Awake()
    {
        tooltip = GetComponentInChildren<Tooltip>();
        neighbourData = GetComponentInChildren<NeighbourData>(true);
        neighbourDialogue = GetComponentInChildren<NeighbourDialogue>(true);
    }

    void Start()
    {
        tooltip.UpdateText(tooltipText);
        scriptLines = neighbourDialogue.script[(int)neighbourData.mood].lines;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        tooltip.showTooltip();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        tooltip.hideTooltip();

        if (other.CompareTag("Player"))
        {
            //playerInside = false;
            MoodDisplay.gameObject.SetActive(false);
        }
    }
}
