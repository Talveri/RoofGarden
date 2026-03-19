using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private List<IInteractable> interactables;

    public IInteractable GetInteractable()
    {
        // later implement distance (and direction?) checking

        if (interactables.Count > 0)
        {
            IInteractable interactable = interactables[0];

            // check if interactable is still valid (e.g. not destroyed)
            if (interactable != null)
            {
                return interactables[0];
            }
            else
            {
                interactables.RemoveAt(0);
                // loop recursively
                // until valid interactable is found
                // or list is empty and null is returned
                return GetInteractable();
            }
        }
        return null;
    }

    private void Start()
    {
        interactables = new List<IInteractable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactables.Add(interactable);
            Debug.Log("Added interactable: " + interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactables.Remove(interactable);
            Debug.Log("Removed interactable: " + interactable);
        }
    }
}
