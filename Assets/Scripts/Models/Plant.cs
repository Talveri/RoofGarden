
using UnityEngine;
using RoofGardenGame.Enums;
using RoofGardenGame.Models.Events;
using Unity.VisualScripting;
using System;

namespace RoofGardenGame.Models
{

    public class Plant: MonoBehaviour
    {
        [Tooltip("Which plant is it?")]
        [SerializeField]
        PlantType type;
        
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
            dayPlanted = DayCycleManager.GetCurrentDay();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprites[spriteStartIndex];
        }

        public bool IsGrown()
        {
            int currentDay = DayCycleManager.GetCurrentDay();
            return currentDay / growthDurationInDays <= spriteCount;
        }

        
        public Nutrients GetConsumption()
        {
            return consumption;
        }

        public void Progress()
        {
            int index = Math.Min(spriteStartIndex + GetAge() / growthDurationInDays, spriteStartIndex + spriteCount);
            spriteRenderer.sprite = sprites[index];
        }

        /// <summary>
        /// age in days
        /// </summary>
        public int GetAge()
        {
            return DayCycleManager.GetCurrentDay() - dayPlanted;
        }

        public void ReceiveNutrients(ref Nutrients nutrients)
        {
            if (!IsGrown())
            {
                if(!nutrients.Contains(consumption)) // insufficient nutrients
                {
                    health -= 1;
                }
                nutrients -= consumption;
            }
            else
            {
                int dayWhenGrowthEnds = dayPlanted + spriteCount * growthDurationInDays;
                int daysSpentInGrownState = DayCycleManager.GetCurrentDay() - dayWhenGrowthEnds;
                if (daysSpentInGrownState > 0)
                {
                    // Placeholder for post-growth logic, such as fruit production or decay
                }
                health += 1;
                
            }
            health = Math.Clamp(health, 0, maxHealth);
        }

        public static Relationship operator+(Plant left, Plant right)
        {
            // this is arbitrary math. feel free to implement the relationships
            // how you see fit.
            if ((int)left.type % 2 == (int)right.type % 2)
            {
                return Relationship.Beneficial;
            }
            return Relationship.Neutral;
        }
    }

}