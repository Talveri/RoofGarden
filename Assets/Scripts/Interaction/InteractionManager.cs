using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private List<IInteractable> interactables;

    /**
     * <summary>
     * Gets the first valid <see cref="IInteractable"/> in the list, which is sorted by distance (closest first).
     * </summary>
     * <returns>The closest <see cref="IInteractable"/></returns>
     */
    public IInteractable GetInteractable()
    {
        if (interactables.Count > 0)
        {
            for (int i = 0; i < interactables.Count; i++)
            {
                IInteractable interactable = interactables[i];
                // check if interactable is still valid (e.g. not destroyed)
                if (interactable != null)
                {
                    return interactable;
                }
                else
                {
                    interactables.RemoveAt(i);
                    i--;
                }
            }
        }
        return null;
    }

    /**
     * <summary>
     * Just like <see cref="GetInteractable()"/>, but with a type filter."/>
     * </summary>
     * <returns>The closest <see cref="IInteractable"/> of type T</returns>
     */
    public IInteractable GetInteractable<T>()
    {
        if (interactables.Count > 0)
        {
            for (int i = 0; i < interactables.Count; i++)
            {
                IInteractable interactable = interactables[i];
                // check if interactable is still valid (e.g. not destroyed)
                if (interactable != null)
                {
                    // check if interactable is of the correct type
                    if (interactable is T)
                    {
                        return interactable;
                    }
                }
                else
                {
                    interactables.RemoveAt(i);
                    i--;
                }
            }
        }
        return null;
    }

    private void SortInteractables()
    {
        interactables.Sort(
            (a, b) =>
            {
                float distanceA = Vector2.Distance(
                    transform.position,
                    ((MonoBehaviour)a).transform.position
                );
                float distanceB = Vector2.Distance(
                    transform.position,
                    ((MonoBehaviour)b).transform.position
                );
                return distanceA.CompareTo(distanceB);
            }
        );
    }

    private void AddInteractable(IInteractable interactable)
    {
        interactables.Add(interactable);
        Debug.Log("Added interactable: " + interactable);

        SortInteractables();
    }

    private void RemoveInteractable(IInteractable interactable)
    {
        interactables.Remove(interactable);
        Debug.Log("Removed interactable: " + interactable);

        SortInteractables();
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
            AddInteractable(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null)
        {
            RemoveInteractable(interactable);
        }
    }
}
