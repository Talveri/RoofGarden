using RoofGardenGame.Enums;
using RoofGardenGame.Models.Events;

namespace RoofGardenGame.Models
{

    public class Plant
    {
        public bool IsGrown => Age >= GrowTime;

        private PlantType Type;
        private int plantDay;
        private int Age;
        private int GrowTime = 10;

        public Plant(PlantType type)
        {
            Type = type;
            plantDay = 0;
            Age = 0;
        }

        public void ProgressDay(DayEvent dayEvent, WaterLevel waterLevel)
        {
            Age = dayEvent.Day - plantDay;
            if (!IsGrown)
            {
                AbsorbWater(waterLevel);
                ConsumeNutrients();
            }
            else
            {
                int grownDays = dayEvent.Day - (plantDay + GrowTime);
                if (grownDays > 0)
                {
                    // Placeholder for post-growth logic, such as fruit production or decay
                }
            }
        }

        public void GetConsumption()
        {
            // Placeholder for nutrient consumption logic based on plant type and age
        }

        public void GiveNutrients()
        {
            // Placeholder for nutrient absorption logic
        }

        private void ConsumeNutrients()
        {
            // Placeholder for nutrient consumption logic
        }

        private void AbsorbWater(WaterLevel waterLevel)
        {
            // Placeholder for water absorption logic based on water level
        }
    }

}