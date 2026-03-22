using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
{
    
    Transform originalParent;   // previous Slot
    CanvasGroup canvasGroup;
    void Start()
    {
       canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;  // save OG parent
        transform.SetParent(transform.root);    // above other canvas
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;   // semi-transparent during drag
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // follow mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // Enables raycasts
        canvasGroup.alpha = 1f; // no longer transparent

        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>(); //slot where item dropped

        if(dropSlot == null)
        {
            GameObject dropItem = eventData.pointerEnter;
            if(dropItem != null)
            {
                dropSlot = dropItem.GetComponent<Slot>();
            }
        }
        
        Slot originalSlot = originalParent.GetComponent<Slot>();

        if(dropSlot != null)
        {
            if(dropSlot.currentItem != null)
            {
                // Slot has item -> swap items
                Debug.Log("Attempt Swap...");
                dropSlot.currentItem.transform.SetParent(originalSlot.transform);
                originalSlot.currentItem = dropSlot.currentItem;
                dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
            else
            {
                Debug.Log("No swap");
                originalSlot.currentItem = null;
            }

            //Move Item into dropslot

            transform.SetParent(dropSlot.transform);
            dropSlot.currentItem = gameObject;
        }
        else
        {
            //No slot under drop point
            Debug.Log("No slot");
            transform.SetParent(originalParent);
        }
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //Center
    }

}
