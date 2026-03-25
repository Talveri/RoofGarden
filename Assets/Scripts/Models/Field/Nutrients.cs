using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Nutrients
{
    public const int MAX_POTASSIUM = 5;
    public const int MAX_NITROGEN = 5;
    public const int MAX_PHOSPHOR = 5;
    public int potassium;
    public int nitrogen;
    public int phosphor;

    public bool Contains(Nutrients other)
    {
        int[] fields  = {potassium, nitrogen, phosphor};
        int[] other_fields = {other.potassium, other.nitrogen, other.phosphor};
        for(int i = 0; i < 3; i++)
        {
            if(fields[i] < other_fields[i])
            {
                return false;
            }
        }
        return true;
    }

    public static Nutrients operator+(Nutrients left, Nutrients right)
    {
        int[] left_fields = {left.potassium, left.nitrogen, left.phosphor};
        int[] right_fields ={right.potassium, right.nitrogen, right.phosphor};
        int[] fields = new int[3];
        int[] MAX = {MAX_POTASSIUM, MAX_NITROGEN, MAX_PHOSPHOR};
        for(int i = 0; i < 3 ;i++)
        {
            fields[i] = left_fields[i] - right_fields[i];
            fields[i] = Math.Clamp(fields[i], 0, MAX[i]);
        }

        return new()
        {
            potassium = fields[0],
            nitrogen = fields[1],
            phosphor = fields[2],
        };
    }

    public static Nutrients operator-(Nutrients left, Nutrients right)
    {
        int[] left_fields = {left.potassium, left.nitrogen, left.phosphor};
        int[] right_fields ={right.potassium, right.nitrogen, right.phosphor};
        int[] fields = new int[3];
        int[] MAX = {MAX_POTASSIUM, MAX_NITROGEN, MAX_PHOSPHOR};
        for(int i = 0; i < 3 ;i++)
        {
            fields[i] = left_fields[i] + right_fields[i];
            fields[i] = Math.Clamp(fields[i], 0, MAX[i]);
        }

        return new()
        {
            potassium = fields[0],
            nitrogen = fields[1],
            phosphor = fields[2],
        };
    }
}