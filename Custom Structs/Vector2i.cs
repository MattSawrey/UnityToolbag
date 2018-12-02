using System;
using UnityEngine;
using UnityEditor;

[Serializable]
public struct Vector2i
{
    public int x, y;

    //Constructors:
    public Vector2i(int x, int y){this.x = x; this.y = y;}

    //Basic static methods:
    public static Vector2i Zero() { return new Vector2i(0, 0); }
    public static Vector2i One() { return new Vector2i(1, 1); }
    public static Vector2i Left() { return new Vector2i(-1, 0); }
    public static Vector2i Right() { return new Vector2i(1, 0); }
    public static Vector2i Up() { return new Vector2i(0, 1); }
    public static Vector2i Down() { return new Vector2i(0, -1); }

    //Operator overloading:
    public static Vector2i operator +(Vector2i x, Vector2i y){return new Vector2i(x.x + y.x, x.y + y.y);}
    public static Vector2i operator -(Vector2i x, Vector2i y) { return new Vector2i(x.x - y.x, x.y - y.y); }
    public static Vector2i operator *(Vector2i x, Vector2i y) { return new Vector2i(x.x * y.x, x.y * y.y); }
    public static Vector2i operator /(Vector2i x, Vector2i y) { return new Vector2i(x.x / y.x, x.y / y.y); }
    public static bool operator ==(Vector2i x, Vector2i y) { return x.x == y.x && x.y == y.y; }
    public static bool operator !=(Vector2i x, Vector2i y) { return x.x != y.x || x.y != y.y; }

    //Overriding Object inheritence
    public override string ToString() { return String.Format("({0}, {1})", x, y); }
    public override bool Equals(object o){return this == (Vector2i) o;}
    public override int GetHashCode() { return base.GetHashCode(); }
}

[CustomPropertyDrawer(typeof(Vector2i))]
public class Vector2iDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty x = property.FindPropertyRelative("x");
        SerializedProperty y = property.FindPropertyRelative("y");

        position = EditorGUI.PrefixLabel(position, label);

        float labelWidth = 12f;
        int numberOfFields = 2;
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
    }
}