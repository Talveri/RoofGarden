using RoofGardenGame.Enums;
using RoofGardenGame.Models.Events;
using UnityEngine;

namespace RoofGardenGame.Models
{
    [RequireComponent(typeof(FieldSpriteManager))]
    public class Field : MonoBehaviour, IInteractable
    {
        public FieldState FieldState;
        Plant plant;
        Nutrients nutrients = new Nutrients();
        int waterAmount = 0;

        FieldSpriteManager spriteManager;

        public float moisture;
        public float nitrogen;
        public float phosphor;
        public float potassium;

        // Tracker bool so that OnPlantGrown event is only raised once per plant
        private bool isPlantGrown;

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

            plant = null;
            isPlantGrown = false;
        }

        // Seeds Interaction
        public void ReceivePlant(Plant _plant)
        {
            if (plant == null)
            {
                plant = _plant;
                FieldState = FieldState.Planted;
                //plant.transform.SetParent(transform);
                EventBus.RaisePlantPlanted(new PlantEvent(this, plant));
            }
        }

        // Watering Can Interaction
        public void Irrigate()
        {
            if (waterAmount < Water.MAX)
            {
                waterAmount++;
                moisture = (float)waterAmount / Water.MAX;
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
                FeedPlant(tickEvent.DeltaTime);
                plant.Progress();

                if (plant.IsGrown() && !isPlantGrown)
                {
                    isPlantGrown = true;
                    EventBus.RaisePlantGrown(new PlantEvent(this, plant));
                }
            }
        }

        private void FeedPlant(float deltaTime)
        {
            plant.ReceiveNutrientsAndWater(ref nutrients, waterAmount, deltaTime);
            // plant automatically removes nutrients
        }
    }
}
