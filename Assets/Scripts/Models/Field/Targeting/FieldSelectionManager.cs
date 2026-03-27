using RoofGardenGame.Models;
using Unity.VisualScripting;
using UnityEngine;

/**
 * <summary>
 * Detects the player's useCollider getting in contact with the RaisedBed,
 * to then ask the InteractionManager for the closest Field inside the player's collider.
 * </summary>
 * <remarks>Expected to be attached to RaisedBed (Fields container)</remarks>
 */
class FieldSeletionManager : MonoBehaviour
{
    public FieldSelector fieldSelector;

    private InteractionManager interactionManager;

    private bool playerInside = false;

    void Update()
    {
        if (playerInside)
        {
            // interactionManager should be set here, since OnTriggerEnter sets it before setting playerInside to true
            IInteractable interactable = interactionManager.GetInteractable<Field>();
            if (interactable != null)
            {
                Field field = (Field)interactable;
                fieldSelector.SetField(field);
            }
            else
            {
                fieldSelector.ClearField();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Activated FieldSelector");

            // Get the player's InteractionManager
            interactionManager = collision.gameObject.GetComponentInChildren<InteractionManager>();

            playerInside = true;

            fieldSelector.Active(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Deactivated FieldSelector");

        if (collision.gameObject.CompareTag("Player"))
        {
            playerInside = false;

            fieldSelector.Active(false);
            FieldSelector.Instance.ClearField();
        }
    }
}
