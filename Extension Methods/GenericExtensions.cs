using System;
using System.Linq;

public static class GenericExtensions
{
	public static bool IsBetween <T>(this T figure, T lower, T upper) where T : IComparable<T>
	{
		return figure.CompareTo(lower) >= 0 && figure.CompareTo(upper) <= 0;
	}

	public static int ClosestValueUpper(this int[] collection, int targetValue)
	{
		collection.OrderBy(x => x);
		int closestValue = collection[0];
		int minDiff = int.MaxValue;
		for(int i = 0; i < collection.Length; i++)
		{
			int diff = Math.Abs(collection[i] - targetValue);
			if(minDiff > diff)
			{
				minDiff = diff;
			}
			else
			{
				if(minDiff == diff)
					closestValue = collection[i];
				else
					closestValue = collection[i - 1];
				break;
			}
		}
		return closestValue;
	}

	public static int ValueUpper(this int[] collection, int targetValue)
	{
		collection.OrderBy(x => x);
		int closestValue = collection[0];
		for(int i = 0; i < collection.Length; i++)
		{
			if(targetValue <= collection[i])
				return collection [i];
		}
		throw new Exception("targetValue is greater than the largest collection value");
	}

	public static bool AreAllValuesEqual <T>(this T[] array)
    {
        for(int i = 1; i < array.Length; i++)
            if(array[0].Equals(array[i]))
                return false;
        return true;
    }
}
