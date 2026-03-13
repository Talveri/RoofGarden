// To mimick minimal unity object class idk for tiles
using RoofGardenGame.Enums;
using RoofGardenGame.Models.Events;

namespace RoofGardenGame.Models
{
    public class Tile
    {

        private Plant Plant;
        private WaterLevel WaterLevel;

        public Tile()
        {
            Plant = null;
            WaterLevel = WaterLevel.Dry;
            EventBus.OnDayProgressed += ProgressDay;
        }

        public void ReceivePlant(Plant plant)
        {
            if (Plant == null)
            {
                Plant = plant; // instantiate plant prefab
                EventBus.RaisePlantPlanted(new PlantEvent(this, Plant));
            }
        }

        public void WaterTile()
        {
            if (WaterLevel < WaterLevel.Wet)
            {
                WaterLevel++;
            }
        }

        private void ProgressDay(DayEvent dayEvent)
        {
            if (Plant != null)
            {
                Plant.GetConsumption();
                // Determine if consumption can be met
                // Calculate the nutrient loss of the field to give to give required nutrients to the plant (or what can be provided)
                // Then give the plant the nutrients
                GiveNutrientsToPlant();

                Plant.ProgressDay(dayEvent, WaterLevel);
                if(WaterLevel > WaterLevel.Dry)
                {
                    WaterLevel--;
                }
            }
        }

        private void StartDay()
        {
            if (Plant.IsGrown)
            {
                EventBus.RaisePlantGrown(new PlantEvent(this, Plant));
            }
        }

        private void GiveNutrientsToPlant()
        {
            Plant.GiveNutrients();
            // Remove nutrients from field
        }
    }
}