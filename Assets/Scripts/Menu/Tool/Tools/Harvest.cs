using UnityEngine;

public class Harvest : MonoBehaviour, ITool
{
    public void UseToolStart()
    {
        Debug.Log("Uses Harvest");
    }
    public void UseToolHold(){}

    public void UseToolRelease(){}

}

