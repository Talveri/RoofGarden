using UnityEngine;
using UnityEngine.UIElements;

public class Tooltip : MonoBehaviour
{
    UIDocument tooltipUI;
    Label tooltip;


    void Awake()
    {
        tooltipUI = GetComponent<UIDocument>();
        tooltip = tooltipUI.rootVisualElement.Q<Label>("tooltip");
        hideTooltip();
    }

    public void UpdateText(string tooltipText)
    {
        tooltip.text = tooltipText;
    }

    void OnTriggerEnter2D()
    {
        showTooltip();
    }
    void OnTriggerExit2D()
    {
        hideTooltip();
    }

    public void showTooltip()
    {
        tooltip.style.display = DisplayStyle.Flex;
    }

    public void hideTooltip()
    {
        tooltip.style.display = DisplayStyle.None;
    }


}