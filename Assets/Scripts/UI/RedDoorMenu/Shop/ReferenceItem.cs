using UnityEngine;
using UnityEngine.UI;


public class ReferenceItem : MonoBehaviour
{
    private Item self;

    public void SetReference(GameObject referenceItem)
    {
        Item source = referenceItem.GetComponent<Item>();
        if(source == null)
        {
            Debug.LogError("Incorrect Item.");
            return;
        } 
        self = GetComponent<Item>();
        if(self == null)
        {
            Debug.LogError("Replica has no Item component!");
            return;
        }
        self.ID = source.ID;
        self.isShopItem = true;
        
        GetComponent<Image>().sprite = referenceItem.GetComponent<Image>().sprite;
    }
}
