using RoofGardenGame.Models;
using UnityEngine;

public class Fertilizer : MonoBehaviour, ITool
{
    public PlayerMessage playerMessage;

    public void UseToolStart(Field field)
    {
        Debug.Log("Uses Fertilizer");
    }
    public void UseToolHold(Field field){}

    public void UseToolRelease(Field field){}


}