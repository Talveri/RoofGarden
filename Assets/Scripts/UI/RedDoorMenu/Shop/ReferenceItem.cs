using UnityEngine;
using UnityEngine.UI;


public class ReferenceItem : MonoBehaviour
{
    private Item self;

    public void SetReference(GameObject referenceItem)
    {
        if(referenceItem.GetComponent<Item>() == null)
        {
            Debug.LogError("Incorrect Item.");
            return;
        } 
        self = GetComponent<Item>();
        self = referenceItem.GetComponent<Item>();
        self.isShopItem = true;
        
        GetComponent<Image>().sprite = referenceItem.GetComponent<Image>().sprite;
    }
}
