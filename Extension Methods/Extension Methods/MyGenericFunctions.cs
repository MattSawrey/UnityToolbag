using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class MyGenericFunctions 
{
	public static bool IsBetween <T>(this T figure, T lower, T upper) where T : IComparable<T>
	{
		return figure.CompareTo(lower) >= 0 && figure.CompareTo(upper) < 0;
	}
}
