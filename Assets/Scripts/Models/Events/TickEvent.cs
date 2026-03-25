namespace RoofGardenGame.Models.Events
{
    public class TickEvent
    {
        public float DeltaTime;

        public TickEvent(float deltaTime)
        {
            DeltaTime = deltaTime;
        }
    }
}
