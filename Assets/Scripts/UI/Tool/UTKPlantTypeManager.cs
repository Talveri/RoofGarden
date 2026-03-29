using RoofGardenGame.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UTKPlantTypeManager : MonoBehaviour
{
    public static UTKPlantTypeManager Instance;
    public Image image;
    public TMP_Text typeName;
    private Sprite NoPlantImage;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogError($"An Instance of this GameObject already exist. \nDeleting GameObject {gameObject.name}");
            Destroy(gameObject);
        }
        
        NoPlantImage = image.sprite;
    }
    public void UpdatePlantInfo(Plant plant)
    {
        if (plant == null)
        {
            image.sprite = NoPlantImage;
            typeName.text = "empty";
        }
        image.sprite = plant.VegetablePrefab.GetComponent<Image>().sprite;
        typeName.text = plant.VegetablePrefab.name;
    }
}
