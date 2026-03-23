using System;
using UnityEngine.Rendering;

namespace RoofGardenGame.Enums
{
    public enum WaterLevel
    {
        Dry, 
        Moist,
        Wet
    }

    public struct Interval
    {
        public int min;
        public int max;
        public Interval(int _min, int _max)
        {
            min = _min;
            max = _max;
        }
    }

    public static class Water
    {
        public const int MAX = 30;
        public static WaterLevel Level(int waterValue)
        {
            return waterValue switch
            {
                <10 => WaterLevel.Dry,
                <20 => WaterLevel.Moist,
                _   => WaterLevel.Wet
            };
        }
        public static Interval Interval(WaterLevel level)
        {
            return level switch
            {
                WaterLevel.Dry => new Interval(0, 10),
                WaterLevel.Moist => new Enums.Interval(11, 20),
                WaterLevel.Wet => new Enums.Interval(21, 100),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}