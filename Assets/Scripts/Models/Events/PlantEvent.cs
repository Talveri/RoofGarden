namespace RoofGardenGame.Models.Events
{
    public class PlantEvent
    {
        public Plant Plant { get; private set; }
        public Tile Tile { get; private set; }

        public PlantEvent(Tile tile, Plant plant)
        {
            Plant = plant;
            Tile = tile;
        }
    }
}