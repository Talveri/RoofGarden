using System.Collections.Generic;
using RoofGardenGame.Models;
using RoofGardenGame.Enums;
using UnityEditor;
using UnityEngine;
using RoofGardenGame;

/// <summary>
/// SeedPack has an additional Slot property to dynamically allocate plants
/// </summary>

public class SeedPack : MonoBehaviour, ITool
{
    [SerializeField]
    List<Plant> plants;

    private PlantType type = PlantType.Onion;

    private Slot slot;

    /// <summary>
    /// Only PlantSeed items can be used
    /// </summary>

    void Awake()
    {
        slot = GetComponent<Slot>();
        EventBus.OnInteractWithSeedBag += SetSeed;
    }

    void SetSeed(PlantType _type)
    {
        type = _type;
    }

    public void UseToolStart(Field field)
    {
        Debug.Log(type);

        if (field != null)
        {
            //if ())
            if(slot.currentItem != null && slot.currentItem.CompareTag("PlantSeed"))
            {
                type = slot.currentItem.GetComponent<SeedBag>().type;
                field.ReceivePlant(Instantiate(plants[(int)type], field.transform));
                slot.removeCurrentItem();
            }
            else
            {
                PlayerMessage.Instance.MessageTooltip("I need plant seeds.");
            }
        }
    }

    public void UseToolHold(Field field) { }
    public void UseToolRelease(Field field) { }
}