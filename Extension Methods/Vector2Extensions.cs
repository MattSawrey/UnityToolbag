using UnityEngine;

public static class Vector2Extensions
{
    /// <summary>
    /// Rotates around the z axis in 2D.
    /// </summary>
    /// <param name="point">The point to be rotated</param>
    /// <param name="pivot">The around which to rotate the point</param>
    /// <param name="degrees">The number of degrees to be rotated</param>
    /// <returns></returns>
    public static Vector2 RotateAroundPivot(this Vector2 point, Vector2 pivot, float degrees)
    {
        float radians = (Mathf.PI * degrees / 180f);
        float rotatedX = Mathf.Cos(radians) * (point.x - pivot.x) - Mathf.Sin(radians) * (point.y - pivot.y) + pivot.x;
        float rotatedY = Mathf.Sin(radians) * (point.x - pivot.x) + Mathf.Cos(radians) * (point.y - pivot.y) + pivot.y;
        return new Vector2(rotatedX, rotatedY);
    }

    public static Vector3 ToVector3(this Vector2 vector)
    {
        return new Vector3(vector.x, vector.y, 0f);
    }

    public static Vector3 ToVector3(this Vector2 vector, float z)
    {
        return new Vector3(vector.x, vector.y, z);
    }
}