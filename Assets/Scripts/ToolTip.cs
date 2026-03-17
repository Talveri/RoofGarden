using UnityEngine;
using UnityEngine.UIElements;

class Tooltip : MonoBehaviour
{
    public UIDocument tooltipUI;
    private Label tooltip;


    void Awake()
    {
        tooltip = tooltipUI.GetComponent<Label>();
    }


    void showTooltip()
    {
        tooltip.style.display = DisplayStyle.Flex;
    }

    void hideTooltip()
    {
        tooltip.style.display = DisplayStyle.None;
    }


}