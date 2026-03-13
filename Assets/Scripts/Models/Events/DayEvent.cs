namespace RoofGardenGame.Models.Events
{
    public class DayEvent
    {
        public int Day { get; private set; }

        public DayEvent(int dayNum)
        {
            Day = dayNum;
        }
    }
}