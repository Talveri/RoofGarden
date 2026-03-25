
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HotbarController : MonoBehaviour
{
    public GameObject hotbarPanel;
    static GameObject Hotbar;
    public List<Image> ToolPrefabs;
    private int toolCount;
    //private ItemDictionary itemDictionary;
    public GameObject selectorPrefab;
    private GameObject selector;
    private List<GameObject> tools = new List<GameObject>();

    [SerializeField] private int selectedIndex;

    void Awake()
    {
        Hotbar = hotbarPanel;
        toolCount = ToolPrefabs.Count;


        for (int i = 0; i < toolCount; i++)
        {
            GameObject go = Instantiate(ToolPrefabs[i].GameObject(), hotbarPanel.transform);
            tools.Add(go);

            tools[i].GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            //Keys form 0 to i;
        }
        selector = Instantiate(selectorPrefab, tools[selectedIndex].transform);
    }

    public static void activeHotbar(bool active)
    {
        Hotbar.SetActive(active);
    }

    // INPUT SYSTEM
    public void MoveSelector(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        float x = ctx.ReadValue<float>();
        selectedIndex += Mathf.RoundToInt(x);
        if (selectedIndex < 0) selectedIndex = toolCount - 1;
        else{selectedIndex %= toolCount;}
        Debug.Log($"Current Tool: {tools[selectedIndex].name}");
        selector.transform.SetParent(tools[selectedIndex].transform);
        selector.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //Center

    }
    public void UseTool(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        if (!Hotbar.activeSelf) return;     // The Tool shall not trigger if the Hotbar is inactive

        ITool tool = tools[selectedIndex].GetComponent<ITool>();

        if (tool != null)
        {
            tool.UseTool();
        }
        else
        {
            Debug.LogError($"Tool {selectedIndex} is null");
        }
    }
}
