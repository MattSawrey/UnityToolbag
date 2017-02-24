using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class MyFloatFunctions 
{
	public static float ConvertBetweenRanges(this float oldValue, float oldMin, float oldMax,
	                                         float newMin, float newMax)
	{
		float newValue = (((oldValue - oldMin) * (newMax - newMin))/(oldMax - oldMin) + newMin);
		return newValue;
	}	
}
