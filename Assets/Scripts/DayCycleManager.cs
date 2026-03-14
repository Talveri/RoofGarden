using RoofGardenGame.Models.Events;

namespace RoofGardenGame
{
    public static class DayCycleManager
    {
        static private int currentDay = 0;

        static public void EndDay()
        {
            EndDayCycle();
            StartDayCycle();
        }

        static public int GetCurrentDay()
        {
            return currentDay;
        }

        static private void StartDayCycle()
        {
            EventBus.RaiseDayStart(new DayEvent(currentDay));
        }

        static private void EndDayCycle()
        {
            EventBus.RaiseDayEnd(new DayEvent(currentDay));
            currentDay++;
            EventBus.RaiseDayProgressed(new DayEvent(currentDay));
        }
    }
    
}