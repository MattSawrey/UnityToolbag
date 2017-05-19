using UnityEditor;
using UnityEngine;

public static class EditorGUIStatics
{
    public static void DrawColoredGUIBox(Rect boxRect, Color boxColor)
    {
        Color backgroundColor = GUI.backgroundColor;
        GUI.backgroundColor = boxColor;
        GUI.Box(boxRect, GUIContent.none, new GUIStyle() { normal = new GUIStyleState() { background = Texture2D.whiteTexture } });
        GUI.backgroundColor = backgroundColor;
    }

    public static void DrawColoredGUIBoxWithBorder(Rect boxRect, Color boxColor, float borderThickness, Color borderColor)
    {
        Color backgroundColor = GUI.backgroundColor;
        GUI.backgroundColor = boxColor;
        GUI.Box(boxRect, GUIContent.none, new GUIStyle() { normal = new GUIStyleState() { background = Texture2D.whiteTexture } });
        GUI.backgroundColor = backgroundColor;

        Vector2 topLeft = boxRect.position;
        Vector2 topRight = new Vector2(boxRect.position.x + boxRect.width, boxRect.position.y);
        Vector2 bottomLeft = new Vector2(boxRect.position.x, boxRect.position.y+boxRect.height);
        Vector2 bottomRight = new Vector2(boxRect.position.x + boxRect.width, boxRect.position.y + boxRect.height);

        DrawLine(topLeft, topRight, borderColor, borderThickness);
        DrawLine(topRight, bottomRight, borderColor, borderThickness);
        DrawLine(bottomRight, bottomLeft, borderColor, borderThickness);
        DrawLine(bottomLeft, topLeft, borderColor, borderThickness);
    }

    public static string AddHorizontalSeperationLine()
    {
        return EditorGUILayout.TextArea("", GUI.skin.horizontalSlider);
    }

    public static void AddVerticalSeperatorLine()
    {
        GUI.color = Color.gray;
        EditorGUILayout.LabelField("|", EditorStyles.boldLabel, GUILayout.MaxWidth(10f), GUILayout.MaxHeight(4f));
        GUI.color = Color.white;
    }

    public static void DrawLine(Vector2 startPos, Vector2 endPos, Color colour, float thickness)
    {
        Handles.color = colour;
        Handles.DrawAAPolyLine(thickness, new Vector3[] { startPos, endPos });
        Handles.color = Color.white;
    }

    public static void DrawBackgroundGrid(Rect scrollViewRect, Vector2 scrollPos, float gridSquareWidth,
        Color lineColour, float lineThickness)
    {
        DrawBackgroundGrid(scrollViewRect, scrollPos, gridSquareWidth, lineColour, lineThickness/2.5f, 1);
    }

    public static void DrawBackgroundGrid(Rect scrollViewRect, Vector2 scrollPos, float gridSquareWidth, Color lineColour, float lineThickness, int thickerLineInterval)
    {
        if (Event.current.type == EventType.Repaint)
        {
            Vector2 offset = new Vector2(Mathf.Abs(scrollPos.x % gridSquareWidth - gridSquareWidth),
                                            Mathf.Abs(scrollPos.y % gridSquareWidth - gridSquareWidth));

            int numXLines = Mathf.CeilToInt((scrollViewRect.width + (gridSquareWidth - offset.x)) / gridSquareWidth);
            int numYLines = Mathf.CeilToInt((scrollViewRect.height + (gridSquareWidth - offset.y)) / gridSquareWidth);

            for (int x = 0; x < numXLines; x++)
            {
                float lineThicknessToUse = x % thickerLineInterval == 0 ? lineThickness * 2.5f : lineThickness;
                DrawLine(new Vector2(offset.x + (x * gridSquareWidth) + scrollViewRect.x, 0f) + scrollPos,
                    new Vector2(offset.x + (x * gridSquareWidth) + scrollViewRect.x, scrollViewRect.height) + scrollPos, lineColour, lineThicknessToUse);
            }

            for (int y = 0; y < numYLines; y++)
            {
                float lineThicknessToUse = y % thickerLineInterval == 0 ? lineThickness * 2.5f : lineThickness;
                DrawLine(new Vector2(scrollViewRect.x, offset.y + (y * gridSquareWidth) + scrollViewRect.y) + scrollPos,
                    new Vector2(scrollViewRect.x + scrollViewRect.width, offset.y + (y * gridSquareWidth) + scrollViewRect.y) + scrollPos, lineColour, lineThicknessToUse);
            }
        }
    }

    public static void DrawNodeCurve(Rect start, Rect end)
    {
        DrawNodeCurve(start, end, Color.black, 0.5f);
    }

    public static void DrawNodeCurve(Rect start, Rect end, Color color, float curveStrength)
    {
        Vector3 startPos = new Vector3(start.x + start.width / 2, start.y + start.height / 2, 0);
        Vector3 endPos = new Vector3(end.x + end.width / 2, end.y + end.height / 2, 0);
        Vector3 startTan = startPos + Vector3.right * (curveStrength*100);
        Vector3 endTan = endPos + Vector3.left * (curveStrength * 100);
        Color shadowCol = new Color(0, 0, 0, .1f);

        for (int i = 0; i < 3; i++)
        {
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
        }
        Handles.color = color;
        Handles.DrawBezier(startPos, endPos, startTan, endTan, color, null, 2);
        Handles.color = Color.white;
    }

    public static void DrawNodeLine(Rect start, Rect end, Color color)
    {
        Vector3 startPos = new Vector3(start.x + start.width / 2, start.y + start.height / 2, 0);
        Vector3 endPos = new Vector3(end.x + end.width / 2, end.y + end.height / 2, 0);

        Handles.color = color;
        Handles.DrawLine(startPos, endPos);
        Handles.color = Color.white;
    }
}