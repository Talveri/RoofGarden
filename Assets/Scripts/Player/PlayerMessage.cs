using System.Collections;
using UnityEngine;

/// The Player Message is used to send messages to the User
/// The Messages appear in form of a tooltip
/// 
/// This script can be called vie PlayerMessage.Instance.MessageTooltip();

public class PlayerMessage : MonoBehaviour
{
    public static PlayerMessage Instance {get; private set; }
    public Tooltip tooltip;
    private Coroutine tooltipRoutine;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void MessageTooltip(string message, float time)
    {
        if(tooltipRoutine != null)
            StopCoroutine(tooltipRoutine);

        tooltip.UpdateText(message);
        tooltipRoutine = StartCoroutine(ShowTooltipRoutine(time));
    }

    private IEnumerator ShowTooltipRoutine(float time)
    {
        tooltip.showTooltip();
        yield return new WaitForSeconds(time);
        tooltip.hideTooltip();
    }
}