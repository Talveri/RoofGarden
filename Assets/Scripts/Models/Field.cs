// To mimick minimal unity object class idk for tiles
using RoofGardenGame.Enums;
using RoofGardenGame.Models.Events;

namespace RoofGardenGame.Models
{
    public class Field
    {
        Plant plant;

        Nutrients nutrients;

        void Awake()
        {
            plant = null;
            EventBus.OnDayProgressed += ProgressDay;
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
    }
}