// To mimick minimal unity object class idk for tiles
using UnityEngine;
using RoofGardenGame.Enums;
using RoofGardenGame.Models.Events;
using Unity.VisualScripting;


namespace RoofGardenGame.Models
{
    public class Field : MonoBehaviour, IInteractable
    {
        public FieldState FieldState;
        Plant plant;
        Nutrients nutrients;
        int waterAmount;

        FieldSpriteManager spriteManager;


        void Awake()
        {
            plant = null;
            EventBus.OnDayProgressed += ProgressDay;
            spriteManager = GetComponent<FieldSpriteManager>();
        }

        public void TillField()
        {
            spriteManager.Tilled();

            FieldState = FieldState.Tilled;
        }

        // Harvest Interaction
        public void Harvest()
        {
            spriteManager.Untilled();
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
                spriteManager.VisualMoisture(waterAmount);
            }
        }

        public void Interact<T>(T data)
        { 
            if(typeof(T) == typeof(PlantType))
            {
                EventBus.RaisePlayerPlanting(
                    new PlantingEvent(this, (PlantType)(object)data)
                );
            }
        }

        private void ProgressDay(DayEvent dayEvent)
        {
            if (plant)
            {
                var required = plant.GetConsumption();
                FeedPlant();
                plant.Progress();
            }
        }

        private void StartDay()
        {
            if (plant.IsGrown())
            {
                EventBus.RaisePlantGrown(new PlantEvent(this, plant));
            }
        }

        private void FeedPlant()
        {
            plant.ReceiveNutrientsAndWater(ref nutrients, waterAmount);
            // plant automatically removes nutrients
        }

    }
}