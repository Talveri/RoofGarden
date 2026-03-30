using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The StatusBar is for displaying a certain value with the
/// StatusBar Sprite
/// </summary>

[System.Serializable]
public struct StatusSprite
{
    public float threshold;
    public Sprite sprite;
}
public class StatusBar : MonoBehaviour
{
    public StatusBar demand = null;
    [SerializeField] private List<StatusSprite> status;
    public void UpdateStatusBar(float value)
    {

        StatusSprite closest = status[0];
        float smDiff = Mathf.Abs(value - closest.threshold);

        foreach(var s in status)
        {
            float diff = Mathf.Abs(value - s.threshold);
            if (diff < smDiff)
            {
                smDiff = diff;
                closest = s;
            }
        }
        GetComponent<Image>().sprite = closest.sprite;   
    }

    public void SetDemand(float value)
    {
        demand.UpdateStatusBar(value);
    }
}
