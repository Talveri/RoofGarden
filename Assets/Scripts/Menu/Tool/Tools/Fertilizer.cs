using UnityEngine;

public class Fertilizer : MonoBehaviour, ITool
{
    public PlayerMessage playerMessage;
    public void UseTool()
    {
        Debug.Log("Uses Fertilizer");
    }
}