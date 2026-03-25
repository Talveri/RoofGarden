using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class UTKPanelController : MonoBehaviour
{

    [Header("Animation Settings")]
    public float slideDuration = 0.3f;
    public Vector2 hiddenPos = new Vector2(600, 0);
    public Vector2 visiblePos = new Vector2(0, 0);

    private RectTransform rect;
    private Coroutine slideRoutine;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        rect.anchoredPosition = hiddenPos;
    }

    public void Show()
    {
        if (rect.anchoredPosition == visiblePos)
            return;
        StartSlide(visiblePos);
    }
    public void Hide()
    {
        if (rect.anchoredPosition == hiddenPos)
            return;
        StartSlide(hiddenPos);
    }

    private void StartSlide(Vector2 target)
    {
        if (slideRoutine != null)
            StopCoroutine(slideRoutine);

        slideRoutine = StartCoroutine(SlideTo(target));
    }

    private IEnumerator SlideTo(Vector2 target)
    {
        Vector2 start = rect.anchoredPosition;
        float t = 0f;

        while (t < slideDuration)
        {
            t += Time.deltaTime;
            float lerp = Mathf.SmoothStep(0f, 1f, t / slideDuration);
            rect.anchoredPosition = Vector2.Lerp(start, target, lerp);
            yield return null;
        }



    }
}
