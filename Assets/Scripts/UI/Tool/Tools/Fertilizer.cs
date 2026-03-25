using UnityEngine;

public class Fertilizer : MonoBehaviour, ITool
{
    public PlayerMessage playerMessage;

    public void UseToolStart()
    {
        Debug.Log("Uses Fertilizer");
    }
    public void UseToolHold(){}

    public void UseToolRelease(){}


}