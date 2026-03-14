namespace RoofGardenGame.Models.Events
{
    public class PlantEvent
    {
        public Plant Plant { get; private set; }
        public Field Field { get; private set; }

        public PlantEvent(Field _field, Plant _plant)
        {
            Plant = _plant;
            Field = _field;
        }
    }
}