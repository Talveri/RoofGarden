using System.Collections;
using UnityEngine;

public class CheckWinCondition : MonoBehaviour
{
    public static CheckWinCondition Instance { get; private set; }
    public GameObject WinScreen;
    public GameObject GameOverScreen;
    public Transform CameraPosition;
    public NeighbourData[] neighbours;
    public ScreenFader fader;
    public GameObject Panel;

    void Awake()
    {
        Instance = this;
        WinScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        titleGroup.alpha = 0;
    }

    void Start()
    {
        foreach (NeighbourData data in neighbours)
            data.mood = RoofGardenGame.Enums.Mood.VeryUnhappy;
    }

    public bool Check()
    {
        foreach (NeighbourData data in neighbours)
        {
            if (data.mood != RoofGardenGame.Enums.Mood.VeryHappy)
                return false;
        }
        Panel.SetActive(false);

        StartCoroutine(WinGame());
        return true;
    }

    private IEnumerator WinGame()
    {
        fader.fadeOutTime = 0.5f;
        yield return StartCoroutine(fader.FadeOut());
        WinScreen.SetActive(true);
        EndGame();
        yield return StartCoroutine(fader.FadeIn());
        FadeInTitle();
    }

    public void LoseGame()
    {
        StartCoroutine(fader.FadeOut());
        GameOverScreen.SetActive(true);
        EndGame();
        StartCoroutine(fader.FadeIn());

    }
    private void EndGame()
    {
        InputMapManager.setToUI();
        InputMapManager.SetGlobalActionMap(false);
        Camera.main.transform.position = CameraPosition.position;
    }

    public CanvasGroup titleGroup;

    private void FadeInTitle(float duration = 1f)
    {
        StartCoroutine(FadeInRoutine(duration));
    }

    private IEnumerator FadeInRoutine(float duration)
    {
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            titleGroup.alpha = Mathf.Lerp(0f, 1f, time / duration);
            yield return null;
        }

        titleGroup.alpha = 1f;
    }

}
