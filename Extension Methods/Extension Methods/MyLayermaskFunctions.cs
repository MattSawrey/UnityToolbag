using UnityEngine;
using System.Collections;

public static class MyLayermaskFunctions
{
	public static int LayerNumber (this LayerMask layerMask)
	{
		int result = (int)Mathf.Sqrt(layerMask.value)/2;
		return result;
	}
}
