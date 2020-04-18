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
        return Mathf.Round(value * roundingFactor) / roundingFactor;
    }

    public static float RoundToNearest(this float value, float nearestValue)
    {
        float diff = value % nearestValue;
        float result = 0f;

        if (diff < nearestValue / 2f)
            result = value - diff;
        else
            result = value + nearestValue - diff;

        return result;
    }

    public static float PercentageOf(this float value, float pcOfValue, int numDecimalPoints)
    {
        return value.PercentageOf(pcOfValue).RoundTo(numDecimalPoints);
    }

    public static float PercentageOf(this float value, float pcOfValue)
    {
        return ((pcOfValue - (pcOfValue - value)) / pcOfValue) * 100f;
    }

    //Snaps the float value to the nearest number that is divisible by the provided divisible value
    public static float GetNearestWholeMultipleOf(this float value, float multipleOfValue)
    {
        return Mathf.Round(value / multipleOfValue) * multipleOfValue;
    }

    public static float GetNearestWholeMultipleOfWithOffset(this float value, float multipleOfValue, float offsetValue)
    {
        return (Mathf.Round((value - offsetValue) / multipleOfValue) * multipleOfValue) + offsetValue;
    }

    // FInds the index of the nearest value in the given arrays
    public static int BinarySearchNearestIndex(this float[] a, float item)
    {
        int first = 0;
        int last = a.Length - 1;
        int mid = 0;
        do
        {
            mid = first + (last - first) / 2;
            if (item > a[mid])
                first = mid + 1;
            else
                last = mid - 1;
            if (a[mid] == item)
                return mid;
        } while (first <= last);
        return mid;
    }
}
