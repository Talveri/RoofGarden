
using UnityEngine;
using RoofGardenGame.Enums;
using RoofGardenGame.Models.Events;
using Unity.VisualScripting;

namespace RoofGardenGame.Models
{

    public class Plant: MonoBehaviour
    {
        [SerializeField]
        private PlantType type;
        
        [SerializeField]
        private Nutrients consumption;

        [SerializeField]
        private int finalGrowthStage;

        [SerializeField]
        private int growthDuration;

        [SerializeField]
        private int spriteIndex;

        [SerializeField]
        private int health;

        private int dayPlanted;


        void Awake()
        {
            // runs the moment the plant is instantiated during the game
            dayPlanted = DayCycleManager.GetCurrentDay();
        }

        public bool IsGrown()
        {
            int currentDay = DayCycleManager.GetCurrentDay();
            return currentDay / growthDuration <= finalGrowthStage;
        }

        
        public Nutrients GetConsumption()
        {
            return consumption;
        }

        public void Progress()
        {
            // TODO: buncha stuff
            // should be called after ReceiveNutrients()
            // code goes here that changes the sprite depending
            // on how many days the plant has been growing

            // pseudocode:
            // spritegameobject.index = spriteIndex + GetAge() / growthDuration
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
                if(!nutrients.Contains(consumption))
                {
                    health -= 1;
                }
                nutrients -= consumption;
            }
            else
            {
                int dayWhenGrowthEnds = dayPlanted + finalGrowthStage*growthDuration;
                int grownDays = DayCycleManager.GetCurrentDay() - dayWhenGrowthEnds;
                if (grownDays > 0)
                {
                    // Placeholder for post-growth logic, such as fruit production or decay
                }
            }
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