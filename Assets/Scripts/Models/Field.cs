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

        public List<Sprite> soilSprites;
        SpriteRenderer sr;

        void Awake()
        {
            plant = null;
            EventBus.OnDayProgressed += ProgressDay;

            sr = GetComponent<SpriteRenderer>();
        }

        public void ReceivePlant(Plant _plant)
        {
            if (plant == null)
            {
                plant = _plant;
                EventBus.RaisePlantPlanted(new PlantEvent(this, plant));
            }
        }

        public void Water()
        {
            if (nutrients.water < Nutrients.MAX_WATER)
            {
                nutrients.water++;
                ChangeAlpha(0.3f);
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
            plant.ReceiveNutrients(ref nutrients);
            // plant automatically removes nutrients
        }

        private void ChangeAlpha(float alpha){
            Color c = sr.color;
            c.a = alpha;
            sr.color = c;
        }
    }
}