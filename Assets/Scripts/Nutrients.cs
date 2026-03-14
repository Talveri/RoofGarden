using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Nutrients
{
    public const int MAX_PHOSPHOR = 5;
    public const int MAX_NITROGEN = 5;
    public const int MAX_SODIUM = 5;
    public const int MAX_WATER = 5;
    public int phosphor;
    public int nitrogen;
    public int sodium;
    public int water;

    public bool Contains(Nutrients other)
    {
        int[] fields  = {phosphor, nitrogen, sodium, water};
        int[] other_fields = {other.phosphor, other.nitrogen, other.sodium, other.water};
        for(int i = 0; i < 4; i++)
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
        int[] left_fields = {left.phosphor, left.nitrogen, left.sodium, left.water};
        int[] right_fields ={right.phosphor, right.nitrogen, right.sodium, right.water};
        int[] fields = new int[4];
        int[] MAX = {MAX_PHOSPHOR, MAX_NITROGEN, MAX_SODIUM, MAX_WATER};
        for(int i = 0; i < 4 ;i++)
        {
            fields[i] = left_fields[i] - right_fields[i];
            fields[i] = Math.Clamp(fields[i], 0, MAX[i]);
        }

        return new()
        {
            phosphor = fields[0],
            nitrogen = fields[1],
            sodium = fields[2],
            water = fields[3]
        };
    }

    public static Nutrients operator-(Nutrients left, Nutrients right)
    {
        int[] left_fields = {left.phosphor, left.nitrogen, left.sodium, left.water};
        int[] right_fields ={right.phosphor, right.nitrogen, right.sodium, right.water};
        int[] fields = new int[4];
        int[] MAX = {MAX_PHOSPHOR, MAX_NITROGEN, MAX_SODIUM, MAX_WATER};
        for(int i = 0; i < 4 ;i++)
        {
            fields[i] = left_fields[i] + right_fields[i];
            fields[i] = Math.Clamp(fields[i], 0, MAX[i]);
        }

        return new()
        {
            phosphor = fields[0],
            nitrogen = fields[1],
            sodium = fields[2],
            water = fields[3]
        };
    }
}