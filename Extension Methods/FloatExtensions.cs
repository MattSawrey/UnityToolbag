using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class FloatExtensions 
{
	public static float ConvertToRange(this float oldValue, float oldMin, float oldMax,
	                                         float newMin, float newMax)
	{
        return (((oldValue - oldMin) * (newMax - newMin)) / (oldMax - oldMin) + newMin); 
	}	
}
