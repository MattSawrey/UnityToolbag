using System;

public static class GenericExtensions
{
	public static bool IsBetween <T>(this T figure, T lower, T upper) where T : IComparable<T>
	{
		return figure.CompareTo(lower) >= 0 && figure.CompareTo(upper) < 0;
	}
}
