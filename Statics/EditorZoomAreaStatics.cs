using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// A simple class providing static access to functions that will provide a 
/// zoomable area similar to Unity's built in BeginVertical and BeginArea
/// Systems. Code based off of article found at:
/// http://martinecker.com/martincodes/unity-editor-window-zooming/
///  
/// (Site may be down)
/// </summary>
public class EditorZoomAreaStatics
{
    private static Stack<Matrix4x4> previousMatrices = new Stack<Matrix4x4>();
    public static Rect Begin(float zoomScale, Rect screenCoordsArea)
    {
        GUI.EndGroup();

        Rect clippedArea = screenCoordsArea.ScaleSizeBy(1.0f / zoomScale, screenCoordsArea.min);
        //clippedArea.y += 21f;

        //Handles.DrawSolidRectangleWithOutline(clippedArea, Color.clear, Color.yellow);

        GUI.BeginGroup(new Rect(0f, 21f / zoomScale, clippedArea.width + clippedArea.x, clippedArea.height + clippedArea.y));

        previousMatrices.Push(GUI.matrix);
        Matrix4x4 translation = Matrix4x4.TRS(screenCoordsArea.min, Quaternion.identity, Vector3.one);
        Matrix4x4 scale = Matrix4x4.Scale(new Vector3(zoomScale, zoomScale, 1.0f));
        GUI.matrix = translation * scale * translation.inverse;

        return clippedArea;
    }

    /// <summary>
    /// Ends the zoom area
    /// </summary>
    public static void End()
    {
        GUI.matrix = previousMatrices.Pop();
        GUI.EndGroup();
        GUI.BeginGroup(new Rect(0, 21, Screen.width, Screen.height));
    }
}