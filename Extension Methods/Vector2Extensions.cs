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

    public static Vector2 SnapToNearest(this Vector2 value, float snapToValue)
    {
        return new Vector2(value.x.RoundToNearest(snapToValue), value.y.RoundToNearest(snapToValue));
    }

    public static float AngleToVectorInRads(this Vector2 vector, Vector2 vectorTo)
    {
        return Mathf.Atan2(vectorTo.y - vector.y, vectorTo.x - vector.x);
    }

    public static float AngleToInDegrees(this Vector2 vector, Vector2 vectorTo)
    {
        return (AngleToVectorInRads(vector, vectorTo) * 180 / Mathf.PI) + 180;
    }

    public static Vector2 FindMidPointOfCollection(this Vector2[] vectors)
    {
        Vector2 sumOfVectors = Vector2.zero;
        for (int i = 0; i < vectors.Length; i++)
            sumOfVectors += vectors[i];
        return sumOfVectors / vectors.Length;
    }
}