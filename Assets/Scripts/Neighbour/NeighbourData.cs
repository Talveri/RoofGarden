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
    public float MoodXP = 0;

    public MoodState[] MoodImages;

    public Sprite GetMoodImage()
    {
        foreach (MoodState state in MoodImages)
        {
            if (mood == state.mood)
            {
                return state.MoodImage;
            }
        }
        Debug.LogWarning($"Mood {mood} could not be found!");
        return null;
    }

    public void increaseMoodXP(float value)
    {
        MoodXP += value;
    }

    public void ImproveMood()
    {
        // Convert enum to int
        int value = (int)mood;
        Debug.Log(value);
        // Move one step toward 4 (VeryHappy)
        value++;

        // Clamp to valid range
        value = Mathf.Clamp(value, 0, Enum.GetValues(typeof(Mood)).Length - 1);

        // Convert back to enum
        mood = (Mood)value;

        Debug.Log("Mood improved to: " + mood);
    }


}