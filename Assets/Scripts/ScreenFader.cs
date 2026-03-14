using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Image fadeImage;
    public float fadeDuration = 0.5f;

    public IEnumerator FadeOut()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = t / fadeDuration;
            fadeImage.color = new Color(0,0,0,alpha);
            yield return null;
        }
        Debug.Log("FadeOut Done");
    }

    public IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = 1f - (t/fadeDuration);
            fadeImage.color = new Color(0,0,0,alpha);
            yield return null;
        }
    }
}
