using UnityEngine.UI;
using UnityEngine;

public class EnergyIcon : MonoBehaviour
{
    public Sprite[] sprites;
    public Image icon;
    public float energyValue = 1f;

    public void UpdateEnergyValue(float value)
    {
        energyValue = Mathf.Clamp01(value);

        if (energyValue >= 1f)
        {
            icon.sprite = sprites[2];
        }
        else if (energyValue >= 0.5f)
        {
            icon.sprite = sprites[1]; // half
        }
        else
        {
            icon.sprite = sprites[0]; // empty
        }
    }
}
