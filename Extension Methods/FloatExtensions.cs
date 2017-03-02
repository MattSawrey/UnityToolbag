using UnityEngine;

public static class FloatExtensions 
{
	public static float ConvertToRange(this float oldValue, float oldMin, float oldMax, float newMin, float newMax)
	{
        return (((oldValue - oldMin) * (newMax - newMin)) / (oldMax - oldMin) + newMin); 
	}

    public static float RoundTo(this float value, int numDecimalPoints)
    {
        int roundingFactor = (int)Mathf.Pow(10, numDecimalPoints);
        Debug.Log(roundingFactor);
        return Mathf.Round(value * roundingFactor) / roundingFactor;
    }

    public static float PercentageOf(this float value, float pcOfValue)
    {
        return ((pcOfValue - (pcOfValue - value)) / pcOfValue) * 100f;
    }

    public static float PercentageOf(this float value, float pcOfValue, int numDecimalPoints)
    {
        return value.PercentageOf(pcOfValue).RoundTo(numDecimalPoints);
    }
}
