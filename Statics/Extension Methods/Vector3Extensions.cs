using UnityEngine;

public static class Vector3Extensions
{
    /// <summary>
    /// Rotates a point around a pivot in 3D.
    /// </summary>
    /// <param name="point">The point to be rotated</param>
    /// <param name="pivot">The pivot around which to rotate</param>
    /// <param name="angle">The angle of rotation</param>
    /// <returns></returns>
	public static Vector3 RotateAroundPivot(this Vector3 point, Vector3 pivot, Quaternion angle)
	{
        return angle * (point - pivot) + pivot;
    }

    public static Vector2 ToVector2(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.y);
    }
}

