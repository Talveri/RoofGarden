using RoofGardenGame;
using RoofGardenGame.Enums;
using UnityEngine;

public class SeedBag : MonoBehaviour, IInteractable
{
    [SerializeField]
    PlantType type = PlantType.Onion;

    public void Interact<T>(T h)
    {
        Debug.Log(type);
        EventBus.PickupSeed(type);
    }
}
