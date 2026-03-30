using System;

[System.Serializable]
public class Nutrients
{
    public const float MAX_POTASSIUM = 5f;
    public const float MAX_NITROGEN = 5;
    public const float MAX_PHOSPHOR = 5;
    public float potassium;
    public float nitrogen;
    public float phosphor;

    public bool Contains(Nutrients other)
    {
        float[] fields = { potassium, nitrogen, phosphor };
        float[] other_fields = { other.potassium, other.nitrogen, other.phosphor };
        for (int i = 0; i < 3; i++)
        {
            if (fields[i] < other_fields[i])
            {
                return false;
            }
        }
        return true;
    }

    public static Nutrients operator +(Nutrients left, Nutrients right)
    {
        float[] left_fields = { left.potassium, left.nitrogen, left.phosphor };
        float[] right_fields = { right.potassium, right.nitrogen, right.phosphor };
        float[] fields = new float[3];
        float[] MAX = { MAX_POTASSIUM, MAX_NITROGEN, MAX_PHOSPHOR };
        for (int i = 0; i < 3; i++)
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

    public static Nutrients operator -(Nutrients left, Nutrients right)
    {
        float[] left_fields = { left.potassium, left.nitrogen, left.phosphor };
        float[] right_fields = { right.potassium, right.nitrogen, right.phosphor };
        float[] fields = new float[3];
        float[] MAX = { MAX_POTASSIUM, MAX_NITROGEN, MAX_PHOSPHOR };
        for (int i = 0; i < 3; i++)
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

    public static Nutrients operator *(Nutrients left, float scalar)
    {
        float[] left_fields = { left.potassium, left.nitrogen, left.phosphor };
        float[] fields = new float[3];
        float[] MAX = { MAX_POTASSIUM, MAX_NITROGEN, MAX_PHOSPHOR };
        for (int i = 0; i < 3; i++)
        {
            fields[i] = left_fields[i] * scalar;
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
