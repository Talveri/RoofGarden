using RoofGardenGame.Models.Events;
using UnityEngine;

namespace RoofGardenGame
{
    public class DayCycleManager : MonoBehaviour
    {
        [SerializeField]
        [Min(1)]
        private int ticksPerDay = 60; // Amount of ticks that make up a day

        private int currentDay = 0;
        private int currentTick = 0;

        private void Start()
        {
            EventBus.OnTick += HandleTick;
        }

        private void HandleTick(TickEvent tickEvent)
        {
            currentTick++;
            //Debug.Log($"Tick: {currentTick}/{ticksPerDay} of Day {currentDay}");

            if (currentTick == ticksPerDay)
            {
                EndDay();
            }
        }

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
            currentTick = 0;
            currentDay++;
            EventBus.RaiseDayProgressed(new DayEvent(currentDay));
        }
    }
}
