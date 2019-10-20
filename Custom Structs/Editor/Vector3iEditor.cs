using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Vector3i))]
public class Vector3iDrawer : PropertyDrawer 
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty x = property.FindPropertyRelative("x");
        SerializedProperty y = property.FindPropertyRelative("y");
        SerializedProperty z = property.FindPropertyRelative("z");

        position = EditorGUI.PrefixLabel(position, label);

        float labelWidth = 12f;
        int numberOfFields = 3;
        float fieldWidth = ((position.width - (labelWidth * numberOfFields)) / numberOfFields);
        float posx = position.x;

        // X
        EditorGUI.LabelField (new Rect (posx, position.y, labelWidth, position.height), "X"); 
        posx += labelWidth;
        x.intValue = EditorGUI.IntField (new Rect (posx, position.y, fieldWidth, position.height), x.intValue); 
        posx += fieldWidth;
 
        // Y
        EditorGUI.LabelField (new Rect (posx, position.y, labelWidth, position.height), "Y"); 
        posx += labelWidth;
        y.intValue = EditorGUI.IntField (new Rect (posx, position.y, fieldWidth, position.height), y.intValue); 
        posx += fieldWidth;
 
        // Z
        EditorGUI.LabelField (new Rect (posx, position.y, labelWidth, position.height), "Z"); 
        posx += labelWidth;
        z.intValue = EditorGUI.IntField (new Rect (posx, position.y, fieldWidth, position.height), z.intValue); 
        posx += fieldWidth;  
    }
}