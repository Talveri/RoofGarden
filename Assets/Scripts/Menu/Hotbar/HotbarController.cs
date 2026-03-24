
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
    private Key[] hotbarKeys;
    public GameObject selectorPrefab;
    private GameObject selector;
    private List<GameObject> tools = new List<GameObject>();

    [SerializeField] private int selectedIndex;

    void Awake()
    {
        Hotbar = hotbarPanel;
        toolCount = ToolPrefabs.Count;
        //itemDictionary = FindAnyObjectByType<ItemDictionary>();
        hotbarKeys = new Key[toolCount];

        for (int i = 0; i < toolCount; i++)
        {
            GameObject go = Instantiate(ToolPrefabs[i].GameObject(), hotbarPanel.transform);
            tools.Add(go);

            tools[i].GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            //Keys form 0 to i;
            hotbarKeys[i] = i < 9 ? (Key)((int)Key.Digit1 + i) : Key.Digit0;
        }
        selector = Instantiate(selectorPrefab, tools[selectedIndex].transform);
    }

    public static void hideHotbar()
    {
        Hotbar.SetActive(false);
    }
    public static void showHotbar()
    {
        Hotbar.SetActive(true);
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

        ITool tool = tools[selectedIndex].GetComponent<ITool>();

        if (tool != null)
        {
            tool.UseTool();
        }
        else
        {
            Debug.Log("Cannot Use Tool");
        }
    }
}
