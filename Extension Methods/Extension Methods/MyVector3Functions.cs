using UnityEngine;

public static class MyVector3Functions
{
	public static Vector3 RotateVector3AroundPivot(this Vector3 currentPosition, Vector3 rotationPivot, Quaternion rotationAngle)
	{
		Vector3 result = rotationAngle * (currentPosition - rotationPivot) + rotationPivot;
		return result;
	}

	public static Vector3 RotateVector3AroundPivot(this Vector3 currentPosition, Vector3 rotationPivot, Vector3 eulerAngle)
	{
		return RotateVector3AroundPivot(currentPosition, rotationPivot, Quaternion.Euler(eulerAngle));
	}
}

