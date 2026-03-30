using UnityEngine;
using System.Collections;
using UnityEngine.UI;

class NeighbourMenuManager : MonoBehaviour
{
    public static NeighbourMenuManager Instance { get; private set; }
    NeighbourData neighbourData;
    public float MAX_MOOD_XP = 10;
    public StatusBar statusBar;
    public Image moodImage;
    public Slot slot;

    void Start()
    {
        Instance = this;
    }

    public void SetNeighbourData(NeighbourData nD)
    {
        neighbourData = nD;
        moodImage.sprite = neighbourData.GetMoodImage();
    }

    // OnButtonPress
    public void ReceiveItem()
    {
        Debug.Log("ReceiveItem");
        if (slot.currentItem == null) return;
        Item item = slot.currentItem.GetComponent<Item>();

        if (item == null || item.moodValue <= 0)
        {
            StartCoroutine(FlashSlot());
            return;
        }

        if(InventoryController.Instance.RemItem(item.gameObject)){
            ImproveMood(item);
            slot.removeCurrentItem();
            CheckWinCondition.Instance.Check();
            return;
        }
        Debug.LogError("ReceiveItem failed");
    }

    public void ImproveMood(Item item)
    {
        neighbourData.increaseMoodXP(item.moodValue);
        if (neighbourData.MoodXP >= MAX_MOOD_XP)
        {   
            Debug.Log("ImproveMood");
            neighbourData.MoodXP %= MAX_MOOD_XP;
            neighbourData.ImproveMood();

            moodImage.sprite = neighbourData.GetMoodImage();
        }
        statusBar.UpdateStatusBar(neighbourData.MoodXP/MAX_MOOD_XP);
    }

    // make slot flash red
    public IEnumerator FlashSlot(float flashDuration = 0.2f)
    {
        Image slotBG = slot.gameObject.GetComponent<Image>();
        Color originalColor = slotBG.color;

        slotBG.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        slotBG.color = originalColor;
    }

}
