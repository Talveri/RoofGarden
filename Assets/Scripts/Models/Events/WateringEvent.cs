namespace RoofGardenGame.Models.Events
{
    public class WateringEvent
    {
        public float WaterAmount { get; private set; }
        public Tile Tile { get; private set; }

        public WateringEvent(Tile tile, float waterAmount)
        {
            WaterAmount = waterAmount;
            Tile = tile;
        }
    }
}