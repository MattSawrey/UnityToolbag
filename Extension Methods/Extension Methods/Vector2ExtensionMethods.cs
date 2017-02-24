using UnityEngine;
using System.Collections;

public static class Vector2ExtensionMethods
{
	public static Vector2 MidPointBetweenVector2s(this Vector2 firstPoint, Vector2 secondPoint)
	{
		Vector2 result = Vector2.Lerp(firstPoint, secondPoint, 0.5f);
		return result;
	}
}
