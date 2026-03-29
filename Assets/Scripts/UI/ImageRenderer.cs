using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// The Image Renderer is a Script for holding sprites and Setting them to an Image.
/// It's current use is to display the mood of the neighbour in the neighbour interface.
/// </summary>
public class ImageRenderer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite[] sprites;
    public Image image;

    public void SetSpriteByIndex(int i)
    {
        image.sprite = sprites[i];
    }

}
