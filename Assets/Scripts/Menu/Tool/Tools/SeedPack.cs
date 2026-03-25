using RoofGardenGame.Models;
using UnityEngine;

public class SeedPack : MonoBehaviour, ITool
{
    public void UseToolStart()
    {
        Field field = FieldSelector.Instance.currentField;
        if(field != null)
            field.ReceivePlant(null);
    }
 
    public void UseToolHold(){}
    public void UseToolRelease(){}


}