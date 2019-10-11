using UnityEngine;

public static class RectExtensions
{
    public static Rect ScaleSizeBy(this Rect rect, float scale) 
    { 
        return rect.ScaleSizeBy(scale, rect.center); 
    }
    
    public static Rect ScaleSizeBy(this Rect rect, float scale, Vector2 pivotPoint)
    {
        Rect result = rect;

        //"translate" the top left to something like an origin
        result.x -= pivotPoint.x;
        result.y -= pivotPoint.y;

        //Scale the rect
        result.xMin *= scale;
        result.yMin *= scale;
        result.xMax *= scale;
        result.yMax *= scale;

        //"translate" the top left back to its original position
        result.x += pivotPoint.x;
        result.y += pivotPoint.y;

        return result;
    }
}