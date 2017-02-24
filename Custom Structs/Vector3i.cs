using System;

public struct Vector3i
{
    public int x;
    public int y;
    public int z;

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