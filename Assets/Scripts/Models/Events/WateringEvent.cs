namespace RoofGardenGame.Models.Events
{
    public class WateringEvent
    {
        public float WaterAmount { get; private set; }
        public Field Field { get; private set; }

        public WateringEvent(Field tile, float waterAmount)
        {
            WaterAmount = waterAmount;
            Field = tile;
        }
    }
}