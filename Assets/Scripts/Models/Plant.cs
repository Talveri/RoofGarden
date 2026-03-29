using System;
using RoofGardenGame.Enums;
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
        public WaterLevel optimalWaterLevel;

        [Tooltip("What nutrients does the plant consume daily?")]
        [SerializeField]
        Nutrients consumption;

        [Tooltip("How many times can I still fuck up")]
        [SerializeField]
        int maxHealth;

        [Tooltip("Amount of ticks the plant needs to grow")]
        [SerializeField]
        int growthDurationInTicks;

        [Tooltip("All plant sprites of a growth stage")]
        [SerializeField]
        Sprite[] growthStageSprites;

        [Tooltip("Death sprite")]
        [SerializeField]
        Sprite deathSprite;

        [Tooltip("Vegetable on Harvest")]
        public GameObject VegetablePrefab;

        SpriteRenderer spriteRenderer;

        int spriteCount;

        public bool critical = false;

        int health;

        private int age = 0; // age in ticks

        private int ticksPerStage;

        /**
         * <summary>
         * Adjusted ticks per stage for calculating the current stage/sprite
         * by only returning the last index (<see cref="spriteCount"/> - 1) after <see cref="growthDurationInTicks"/>
         * and not in between <see cref="growthDurationInTicks"/> - <see cref="ticksPerStage"/> and <see cref="growthDurationInTicks"/>.
         * </summary>
         */
        private int ticksPerStage_adjusted;

        void Awake()
        {
            // runs the moment the plant is instantiated during the game
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = growthStageSprites[0];
            spriteCount = growthStageSprites.Length;

            ticksPerStage = growthDurationInTicks / spriteCount;
            ticksPerStage_adjusted = growthDurationInTicks / (spriteCount - 1);

            health = maxHealth;
        }

        /**
         * <summary>Gets the plant's growth stage (sprite index)</summary>
         * <returns>An <see cref="int"/> between 0 and <see cref="spriteCount"/></returns>
         */
        private int GetGrowthStage()
        {
            return Math.Min((int)(age / ticksPerStage_adjusted), spriteCount - 1);
        }

        public bool IsGrown()
        {
            return age >= growthDurationInTicks;
        }

        public Nutrients GetConsumption()
        {
            return consumption;
        }

        public void Progress()
        {
            if (!IsGrown() && health > 0)
            {
                age++;
                spriteRenderer.sprite = growthStageSprites[GetGrowthStage()];
            }
            else if (health == 0)
            {
                spriteRenderer.sprite = deathSprite;
                critical = false;
            }
        }

        public void ReceiveNutrientsAndWater(
            ref Nutrients nutrients,
            int waterAmount,
            float deltaTime
        )
        {
            if (!IsGrown())
            {
                if (
                    !nutrients.Contains(consumption * deltaTime)
                    || (waterAmount < Water.Interval(optimalWaterLevel).min)
                ) // insufficient nutrients
                {
                    critical = true;
                }
                else
                {
                    critical = false;
                }
                nutrients -= consumption * deltaTime;
            }

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

        public void TakeDamage()
        {
            health -= 1;
            health = Math.Clamp(health, 0, maxHealth);
        }
    }
}
