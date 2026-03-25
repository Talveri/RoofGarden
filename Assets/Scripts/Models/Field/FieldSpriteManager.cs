using System.Collections.Generic;
using UnityEngine;

public class FieldSpriteManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    SpriteRenderer sr;

    public Sprite untilledField;
    public Sprite tilledField;

    [Header("Alpha Impact")]
    [Tooltip("Higher value -> lesser impact")]
    [SerializeField]
    public float alphaImpactOnIrregation = 10;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = untilledField;
    }

    public void Untilled()
    {
        sr.sprite = untilledField;
    }
    public void Tilled()
    {
        sr.sprite = tilledField;
    }

    // Update is called once per frame
    public void VisualMoisture(float moisture)
    {
        float darkness = Mathf.Clamp01(moisture / alphaImpactOnIrregation);
        DarkenSprite(darkness);
    }

    private void DarkenSprite(float amount)
    {
        // 0 -> no darkening
        // 1 -> fully darkened
        Debug.Log($"Darken by {amount}");
        Color baseColor = Color.white;
        Color darkColor = Color.Lerp(baseColor, Color.black, amount);

        sr.color = darkColor;
    }
}
