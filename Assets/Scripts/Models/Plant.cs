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

        [Tooltip("Amount of ticks the plant needs to grow")]
        [SerializeField]
        int growthDurationInTicks;

        [Tooltip("All plant sprites of a growth stage")]
        [SerializeField]
        Sprite[] growthStageSprites;

        [Tooltip("Death sprite")]
        [SerializeField]
        Sprite deathSprite;

        SpriteRenderer spriteRenderer;

        int spriteCount;

        int health;

        int age = 0; // age in ticks

        int ticksPerStage = 0;

        void Awake()
        {
            // runs the moment the plant is instantiated during the game
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = growthStageSprites[0];
            spriteCount = growthStageSprites.Length;

            ticksPerStage = growthDurationInTicks / spriteCount;

            health = maxHealth;
        }

        /**
         * <summary>Gets the plant's growth stage (sprite index)</summary>
         * <returns>An <see cref="int"/> between 0 and <see cref="spriteCount"/></returns>
         */
        private int GetGrowthStage()
        {
            return Math.Min((int)(age / ticksPerStage), spriteCount - 1);
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
            }
        }

        public void ReceiveNutrientsAndWater(ref Nutrients nutrients, int waterAmount)
        {
            if (!IsGrown())
            {
                if (
                    !nutrients.Contains(consumption)
                    || (Water.Level(waterAmount) != optimalWaterLevel)
                ) // insufficient nutrients
                {
                    health -= 1;
                }
                nutrients -= consumption;
            }
            else { }
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
