using RoofGardenGame.Enums;

namespace RoofGardenGame.Models.Events
{
    public class PlantingEvent
    {
        public PlantType Seed { get; private set; }
        public Field Field { get; private set; }

        public PlantingEvent(Field _field, PlantType _seed)
        {
            Seed = _seed;
            Field = _field;
        }
    }
}
