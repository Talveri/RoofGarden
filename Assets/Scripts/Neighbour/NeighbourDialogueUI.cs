using UnityEngine;

public class NeighbourDialogueUI : MonoBehaviour
{
    public Dialogue dialogue;
    void OnEnable()
    {
       NeighbourDoor.onDoorInteracted += ShowDialogue; 
    }

    void OnDisable()
    {
        NeighbourDoor.onDoorInteracted -= ShowDialogue;
    }

    void ShowDialogue(NeighbourData data)
    {
        dialogue.StartDialogue();
    }
}
