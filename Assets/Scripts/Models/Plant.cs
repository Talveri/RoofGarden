using System;
using RoofGardenGame.Enums;
using RoofGardenGame.Models.Events;
using Unity.VisualScripting;
using UnityEngine;

namespace RoofGardenGame.Models
{
    public class Plant : MonoBehaviour
    {
        [Header("General Settings and Dependencies")]
        [Tooltip("The reference to the day cycle manager the plant should use")]
        private readonly DayCycleManager dayCycleManager;

        [Header("Plant Settings")]
        [Tooltip("Which plant is it?")]
        [SerializeField]
        PlantType type;
        
        [Tooltip("How wet does the plant want the soil to be?")]
        [SerializeField]
        WaterLevel optimalWaterLevel;

        [Tooltip("What nutrients does the plant consume daily?")]
        [SerializeField]
        Nutrients consumption;

        [Tooltip("How many times can I still fuck up")]
        [SerializeField]
        int maxHealth;

        [Tooltip("How many days does it take for the next sprite to appear?")]
        [SerializeField]
        int growthDurationInDays;

        [Tooltip("How many sprites belong to this plant type?")]
        [SerializeField]
        int spriteCount;

        [Tooltip("What is this plant type's first sprite in the sprite array?")]
        [SerializeField]
        int spriteStartIndex;

        [Tooltip("All plant sprites")]
        [SerializeField]
        Sprite[] sprites;

        SpriteRenderer spriteRenderer;

        int dayPlanted;

        int health;

        void Awake()
        {
            // runs the moment the plant is instantiated during the game
            dayPlanted = dayCycleManager.GetCurrentDay();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprites[spriteStartIndex];
        }

        public bool IsGrown()
        {
            int currentDay = dayCycleManager.GetCurrentDay();
            return currentDay / growthDurationInDays <= spriteCount;
        }

        public Nutrients GetConsumption()
        {
            return consumption;
        }

        public void Progress()
        {
            int index = Math.Min(
                spriteStartIndex + GetAge() / growthDurationInDays,
                spriteStartIndex + spriteCount
            );
            spriteRenderer.sprite = sprites[index];
        }

        /// <summary>
        /// age in days
        /// </summary>
        public int GetAge()
        {
            return dayCycleManager.GetCurrentDay() - dayPlanted;
        }

        public void ReceiveNutrientsAndWater(ref Nutrients nutrients, int waterAmount)
        {
            if (!IsGrown())
            {
                if(!nutrients.Contains(consumption) || (Water.Level(waterAmount) != optimalWaterLevel)) // insufficient nutrients
                {
                    health -= 1;
                }
                nutrients -= consumption;
            }
            else
            {
                int dayWhenGrowthEnds = dayPlanted + spriteCount * growthDurationInDays;
                int daysSpentInGrownState = dayCycleManager.GetCurrentDay() - dayWhenGrowthEnds;
                if (daysSpentInGrownState > 0)
                {
                    // Placeholder for post-growth logic, such as fruit production or decay
                }
                health += 1;
            }
            health = Math.Clamp(health, 0, maxHealth);
        }

        public static Relationship operator +(Plant left, Plant right)
        {
            // this is arbitrary math. feel free to implement the relationships
            // how you see fit.
            if ((int)left.type % 2 == (int)right.type % 2)
            {
                return Relationship.Beneficial;
            }
            return Relationship.Neutral;
            throw new NotImplementedException();
        }
    }
}
