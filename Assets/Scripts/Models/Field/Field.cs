using RoofGardenGame.Enums;
using RoofGardenGame.Models.Events;
using UnityEngine;

namespace RoofGardenGame.Models
{
    [RequireComponent(typeof(FieldSpriteManager))]
    public class Field : MonoBehaviour, IInteractable
    {
        public FieldState fieldState;
        public Plant plant;
        Nutrients nutrients = new Nutrients();
        int waterAmount = 0;

        FieldSpriteManager spriteManager;

        public float moisturePercent;
        public float nitrogenPercent;
        public float phosphorPercent;
        public float potassiumPercent;

        // Tracker bool so that OnPlantGrown event is only raised once per plant
        private bool isPlantGrown;

        void Awake()
        {
            plant = null;
            EventBus.OnTick += ProgressTick;
            spriteManager = GetComponent<FieldSpriteManager>();
        }

        public void TillField()
        {
            spriteManager.Tilled();

            fieldState = FieldState.Tilled;
        }

        // Harvest Interaction resets FieldState
        public GameObject Harvest()
        {
            Debug.Log("Harvest Plant");
            GameObject vegetable = plant.VegetablePrefab;
            RemovePlant();
            return vegetable;
        }

        public void RemovePlant()
        {
            Debug.Log("Remove Plant");

            Destroy(plant.gameObject);

            spriteManager.Untilled();
            fieldState = FieldState.Raw;
            plant = null;
            isPlantGrown = false;
        }

        // Seeds Interaction
        public void ReceivePlant(Plant _plant)
        {
            if (plant == null)
            {
                plant = _plant;
                fieldState = FieldState.Planted;
                //plant.transform.SetParent(transform);
                EventBus.RaisePlantPlanted(new PlantEvent(this, plant));
            }
        }

        // Watering Can Interaction
        public void Irrigate()
        {
            if (waterAmount < Water.MAX)
            {
                waterAmount++;
                moisturePercent = (float)waterAmount / Water.MAX;
                spriteManager.VisualMoisture(waterAmount);
            }
        }

        public void AddNutrients(Nutrients nutrientsAmount)
        {
            nutrients.nitrogen = nutrientsAmount.nitrogen;
            nutrients.phosphor = nutrientsAmount.phosphor;
            nutrients.potassium = nutrientsAmount.potassium;

            nitrogenPercent = (float)nutrients.nitrogen / Nutrients.MAX_NITROGEN;
            phosphorPercent = (float)nutrients.phosphor / Nutrients.MAX_PHOSPHOR;
            potassiumPercent = (float)nutrients.potassium / Nutrients.MAX_POTASSIUM;
        }

        public void Interact<T>(T data)
        {
            if (typeof(T) == typeof(PlantType))
            {
                EventBus.RaisePlayerPlanting(new PlantingEvent(this, (PlantType)(object)data));
            }
        }

        private void ProgressTick(TickEvent tickEvent)
        {
            if (plant)
            {
                FeedPlant(tickEvent.DeltaTime);
                plant.Progress();

                if (plant.IsGrown() && !isPlantGrown)
                {
                    isPlantGrown = true;
                    fieldState = FieldState.Harvestable;
                    EventBus.RaisePlantGrown(new PlantEvent(this, plant));
                }
            }
        }

        private void FeedPlant(float deltaTime)
        {
            plant.ReceiveNutrientsAndWater(ref nutrients, waterAmount, deltaTime);
            // plant automatically removes nutrients
        }
    }
}
