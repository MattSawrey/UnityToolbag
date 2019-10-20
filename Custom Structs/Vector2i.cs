using System;

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
