
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour{
    public List<Tool> tools;
    int toolIndex = 0;

    public void MoveLeft()
    {
        toolIndex++;
        Mathf.Clamp(toolIndex, 0, tools.Count - 1);
    }

    public void MoveRight()
    {
        toolIndex--;
        Mathf.Clamp(toolIndex, 0, tools.Count - 1);   
    }

    public void UseTool()
    {
        tools[toolIndex].UseTool();
    }

}