using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NeighbourData : MonoBehaviour
{
    public int mood = 0;
    public List<Sprite> MoodImage;
    private SpriteRenderer spriteRenderer;

    private void EnsureRenderer()
{
    if (spriteRenderer == null)
        spriteRenderer = GetComponent<SpriteRenderer>();
}
    public void ShowStats()
    {
        EnsureRenderer();
        // Clamp happiness
        int index = Mathf.Clamp(mood, 0, MoodImage.Count - 1);

        spriteRenderer.sprite = MoodImage[index];
        gameObject.SetActive(true);
    }

    public void HideStats()
    {
        gameObject.SetActive(false);
    }

    
}