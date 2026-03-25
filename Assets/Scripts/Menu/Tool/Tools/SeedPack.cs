using UnityEngine;

public class SeedPack : MonoBehaviour, ITool
{
    public void UseTool()
    {
        PlayerMessage.Instance.MessageTooltip("Using SeedPack",2f);
    }
}