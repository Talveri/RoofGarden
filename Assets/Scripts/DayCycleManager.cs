using RoofGardenGame.Models.Events;

namespace RoofGardenGame
{

    public class DayCycleManager
    {
        private int currentDay = 0;

        public void EndDay()
        {
            EndDayCycle();
            StartDayCycle();
        }

        public int GetCurrentDay()
        {
            return currentDay;
        }

        private void StartDayCycle()
        {
            EventBus.RaiseDayStart(new DayEvent(currentDay));
        }

        private void EndDayCycle()
        {
            EventBus.RaiseDayEnd(new DayEvent(currentDay));
            currentDay++;
            EventBus.RaiseDayProgressed(new DayEvent(currentDay));
        }
    }
    
}