using System.Collections.Generic;
using UnityEngine;

public class FieldSpriteManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    SpriteRenderer sr;

    [SerializeField] float moistLevel;
    [SerializeField] Sprite untilledField;
    [SerializeField] Sprite tilledField;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
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
    public void AddMoistvalue(float watering)
    {
        moistLevel += watering;
        ChangeAlpha(moistLevel);
    }

    private void ChangeAlpha(float alpha)
    {
        Color c = sr.color;
        c.a = alpha;
        sr.color = c;
    }
}
