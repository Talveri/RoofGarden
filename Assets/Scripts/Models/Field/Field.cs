using RoofGardenGame.Enums;
using RoofGardenGame.Models.Events;
using UnityEngine;

namespace RoofGardenGame.Models
{
    public class Field : MonoBehaviour, IInteractable
    {
        public FieldState FieldState;
        Plant plant;
        Nutrients nutrients;
        int waterAmount;
        FieldSpriteManager spriteManager;

        public float moisture;
        public float nitrogen;
        public float phosphor;
        public float potassium;

        void Awake()
        {
            plant = null;
            EventBus.OnTick += ProgressTick;
            spriteManager = GetComponent<FieldSpriteManager>();
        }

        public void TillField()
        {
            spriteManager.Tilled();

            FieldState = FieldState.Tilled;
        }

        // Harvest Interaction resets FieldState
        public void Harvest()
        {
            spriteManager.Untilled();

            FieldState = FieldState.Raw;
        }

        // Seeds Interaction
        public void ReceivePlant(Plant _plant)
        {
            FieldState = FieldState.Planted;
            if (plant == null)
            {
                plant = _plant;
                EventBus.RaisePlantPlanted(new PlantEvent(this, plant));
            }
        }

        // Watering Can Interaction
        public void Irrigate()
        {
            if (waterAmount < Water.MAX)
            {
                waterAmount ++;
                moisture = waterAmount/Water.MAX;
                spriteManager.VisualMoisture(waterAmount);
            }
        }

        public void Interact<T>(T data)
        {
            if (typeof(T) == typeof(PlantType))
            {
                EventBus.RaisePlayerPlanting(new PlantingEvent(this, (PlantType)(object)data));
            }
        }

        private void ProgressTick(TickEvent tickEvent)
        {
            if (plant)
            {
                FeedPlant();
                plant.Progress();

                if (plant.IsGrown())
                {
                    EventBus.RaisePlantGrown(new PlantEvent(this, plant));
                }
            }
        }

        private void FeedPlant()
        {
            plant.ReceiveNutrientsAndWater(ref nutrients, waterAmount);
            // plant automatically removes nutrients

        }
    }
}
