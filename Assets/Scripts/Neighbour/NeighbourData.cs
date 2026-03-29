using System;
using System.Collections.Generic;
using RoofGardenGame.Enums;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

[System.Serializable]
public struct MoodState
{
    public Mood mood;
    public Sprite MoodImage;
}

public class NeighbourData : MonoBehaviour
{
    public Mood mood = Mood.VeryUnhappy;

    
    public MoodState[] MoodImages;

    public Sprite GetMoodImage()
    {
        foreach(MoodState state in MoodImages)
        {
            if(mood == state.mood)
            {
                return state.MoodImage;
            }
        }
        Debug.LogWarning($"Mood {mood} could not be found!");
        return null;
    }   
 
}