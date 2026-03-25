using RoofGardenGame.Models;
using Unity.VisualScripting;
using UnityEngine;

// The Field selection manager is added to a field that shall be interacted with
// by the player
// The Purpose of this script is to detect the players interaction collider and move the FieldSelector
// to their gameobject

class FieldSeletionManager : MonoBehaviour
{
    public FieldSelector fieldSelector;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fieldSelector.Active(true);
            
            if(GetComponent<Field>() != null)
                fieldSelector.MoveToField(GetComponent<Field>()); // The Field tells the Selector where they need to go and what they are targeting
            else
                Debug.LogError("Missing Field Script");
        }
    }

}