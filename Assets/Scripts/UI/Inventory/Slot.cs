using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject currentItem;
    
    public void removeCurrentItem()
    {
        Destroy(currentItem);
        currentItem = null;
    }
}
