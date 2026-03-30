using RoofGardenGame.Enums;
using RoofGardenGame.Models;
using UnityEngine;

public class Fertilizer : MonoBehaviour, ITool
{
    private Slot slot;
    private Nutrients nutrients;

    void Awake()
    {
        slot = GetComponent<Slot>();
    }
    public void UseToolStart(Field field)
    {
        if (slot.currentItem != null && slot.currentItem.gameObject.CompareTag("Fertilizer"))
        {
            // Use Tool
            ParticleSystemManager.Instance.PlaySplash(field.gameObject.transform.position, Color.sandyBrown);

            nutrients = slot.currentItem.gameObject.GetComponent<FertilizerBag>().getNutrientAmount();
            
            field.AddNutrients(nutrients);
            slot.removeCurrentItem();
            return;
        }
        else
        {
            PlayerMessage.Instance.MessageTooltip("I need Fertilizer.");
            return;
        }
    }

    public void UseToolHold(Field field) { }
    public void UseToolRelease(Field field) { }


}