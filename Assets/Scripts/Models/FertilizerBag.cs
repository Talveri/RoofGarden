using RoofGardenGame;
using RoofGardenGame.Enums;
using UnityEngine;

public class FertilizerBag : MonoBehaviour
{
    private Nutrients nutrients = new Nutrients();

    [SerializeField] int N = 0;
    [SerializeField] int P = 0;
    [SerializeField] int K = 0;

    void Start()
    {
        nutrients.nitrogen = N;
        nutrients.phosphor = P;
        nutrients.potassium = K;
    }
    public Nutrients getNutrientAmount()
    {
        return nutrients;
    }
}