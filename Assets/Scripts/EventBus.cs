using System;
using RoofGardenGame.Models.Events;

namespace RoofGardenGame
{
    public class EventBus
    {
        #region Time Events

        #region Tick Events
        public static event Action<TickEvent> OnTick;

        public static void RaiseTick(TickEvent tickEvent)
        {
            OnTick?.Invoke(tickEvent);
        }
        #endregion

        #region Day Events
        public static event Action<DayEvent> OnDayEnd;
        public static event Action<DayEvent> OnDayProgressed;
        public static event Action<DayEvent> OnDayStart;

        public static void RaiseDayEnd(DayEvent dayEvent)
        {
            OnDayEnd?.Invoke(dayEvent);
        }

        public static void RaiseDayProgressed(DayEvent dayEvent)
        {
            OnDayProgressed?.Invoke(dayEvent);
        }

        public static void RaiseDayStart(DayEvent dayEvent)
        {
            OnDayStart?.Invoke(dayEvent);
        }
        #endregion

        #endregion

        #region Plant Events
        public static event Action<PlantingEvent> OnPlayerPlanting;
        public static event Action<PlantEvent> OnPlantPlanted;
        public static event Action<PlantEvent> OnPlantGrown;
        public static event Action<PlantEvent> OnPlantHarvested;

        public static void RaisePlayerPlanting(PlantingEvent plantingEvent)
        {
            OnPlayerPlanting?.Invoke(plantingEvent);
        }

        public static void RaisePlantPlanted(PlantEvent plantEvent)
        {
            OnPlantPlanted?.Invoke(plantEvent);
        }

        public static void RaisePlantGrown(PlantEvent plantEvent)
        {
            OnPlantGrown?.Invoke(plantEvent);
        }

        public static void RaisePlantHarvested(PlantEvent plantEvent)
        {
            OnPlantHarvested?.Invoke(plantEvent);
        }
        #endregion

        #region Watering Events
        public static event Action<WateringEvent> OnWateringStart;
        public static event Action<WateringEvent> OnWateringEnd;

        public static void RaiseWateringStart(WateringEvent wateringEvent)
        {
            OnWateringStart?.Invoke(wateringEvent);
        }

        public static void RaiseWateringEnd(WateringEvent wateringEvent)
        {
            OnWateringEnd?.Invoke(wateringEvent);
        }
        #endregion
    }
}
