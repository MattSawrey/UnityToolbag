using System;
using UnityEngine;
using UnityEditor;

[Serializable]
public struct Vector3i
{
    public int x, y, z;

    //Constructors:
    public Vector3i(int x, int y, int z) { this.x = x; this.y = y; this.z = z; }

    //Basic static methods:
    public static Vector3i Zero() { return new Vector3i(0, 0, 0); }
    public static Vector3i One() { return new Vector3i(1, 1, 1); }
    public static Vector3i Left() { return new Vector3i(-1, 0, 0); }
    public static Vector3i Right() { return new Vector3i(1, 0, 0); }
    public static Vector3i Up() { return new Vector3i(0, 1, 0); }
    public static Vector3i Down() { return new Vector3i(0, -1, 0); }
    public static Vector3i Forwards() { return new Vector3i(0, 0, 1); }
    public static Vector3i Backwards() { return new Vector3i(0, 0, -1); }
    public int SumOfValues() { return (x * y * z); }

    //Operator overloading:
    public static Vector3i operator +(Vector3i x, Vector3i y) { return new Vector3i(x.x + y.x, x.y + y.y, x.z + y.z); }
    public static Vector3i operator -(Vector3i x, Vector3i y) { return new Vector3i(x.x - y.x, x.y - y.y, x.z - y.z); }
    public static Vector3i operator *(Vector3i x, Vector3i y) { return new Vector3i(x.x * y.x, x.y * y.y, x.z * y.z); }
    public static Vector3i operator /(Vector3i x, Vector3i y) { return new Vector3i(x.x / y.x, x.y / y.y, x.z / y.z); }
    public static bool operator ==(Vector3i x, Vector3i y) { return x.x == y.x && x.y == y.y && x.z == y.z; }
    public static bool operator !=(Vector3i x, Vector3i y) { return x.x != y.x || x.y != y.y || x.z != y.z; }

    //Overriding Object inheritence
    public override string ToString() { return String.Format("({0}, {1}, {2})", x, y, z); }
    public override bool Equals(object o) { return this == (Vector3i)o; }
    public override int GetHashCode(){return base.GetHashCode();}
}

[CustomPropertyDrawer(typeof(Vector3i))]
public class Vector3iDrawer : PropertyDrawer 
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty x = property.FindPropertyRelative("x");
        SerializedProperty y = property.FindPropertyRelative("y");
        SerializedProperty z = property.FindPropertyRelative("z");

        position = EditorGUI.PrefixLabel(position, label);

        float labelWidth = 14f;
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