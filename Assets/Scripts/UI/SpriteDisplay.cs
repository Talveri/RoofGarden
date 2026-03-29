using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// The Image Renderer is a Script for holding sprites and Setting them to an Image.
/// It's current use is to display the mood of the neighbour in the neighbour interface.
/// </summary>
public class SpriteDisplay : MonoBehaviour
{
    [Header("Optional Renderers")]
    public Image uiImage;
    public SpriteRenderer spriteRenderer;

    public void SetSprite(Sprite sprite)
    {
        if (uiImage != null)
            uiImage.sprite = sprite;

        if (spriteRenderer != null)
            spriteRenderer.sprite = sprite;

        if (uiImage == null && spriteRenderer == null)
            Debug.LogWarning($"No renderer assigned on {name}");
    }
}

