
using RoofGardenGame.Models;

public interface ITool 
{
    public void UseToolStart(Field field);
    public void UseToolHold(Field field);
    public void UseToolRelease(Field field);
}