using UnityEngine;


public class TestingKit : MonoBehaviour, ITool
{
    public void UseToolStart()
    {
        Debug.Log("Uses Testing Kit");
    }
    
    public void UseToolHold(){}
    public void UseToolRelease(){}


}