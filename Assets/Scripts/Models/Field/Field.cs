// To mimick minimal unity object class idk for tiles
using UnityEngine;
using RoofGardenGame.Enums;
using RoofGardenGame.Models.Events;
using System.Collections.Generic;

namespace RoofGardenGame.Models
{
    public class Field : MonoBehaviour, IInteractable
    {
        Plant plant;

        Nutrients nutrients;
        int waterAmount;

        public FieldSpriteManager fieldSpriteManager;

        void Awake()
        {
            plant = null;
            EventBus.OnDayProgressed += ProgressDay;

        }

        public void TillField()
        {
            fieldSpriteManager.Tilled();
        }
        public void Harvest()
        {
            fieldSpriteManager.Untilled();
        }

        public void ReceivePlant(Plant _plant)
        {
            if (plant == null)
            {
                plant = _plant;
                EventBus.RaisePlantPlanted(new PlantEvent(this, plant));
            }
        }

        public void Irrigate()
        {
            if (waterAmount < Water.MAX)
            {
<<<<<<< HEAD:Assets/Scripts/Models/Field.cs
                waterAmount ++;
                ChangeAlpha(0.3f);
=======
                nutrients.water++;
>>>>>>> 9cf54f3869a601d82b17c200d3c2d949815e5ae2:Assets/Scripts/Models/Field/Field.cs
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