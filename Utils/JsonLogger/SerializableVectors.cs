/**
 * 
 * Serializable versions of the Vector2 and Vector3 classes, to work with the Newtonsoft JSON.NET library.
 * Implicit operators are provided to allow simple conversion between serialisable and standard types.
 * 
 * E.g.
 *  Vector3 v = new Vector3(1,2,3);
 *  JsonConvert.SerializeObject(v);  // will not work, v is not Serializable.
 *  SerializableVector3 sv = v;      // automatic conversion using implicit operator
 *  JsonConvert.SerializeObject(sv); // will work
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6000.0.53f1
 */

using UnityEngine;

[System.Serializable]
public class SerializableVector2
{
    public float x;
    public float y;

    public SerializableVector2()
    {
        this.x = 0;
        this.y = 0;
    }

    public SerializableVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public SerializableVector2(Vector2 v)
    {
        this.x = v.x;
        this.y = v.y;
    }

    public static implicit operator Vector2(SerializableVector2 sv) => new Vector2(sv.x, sv.y);
    public static implicit operator SerializableVector2(Vector2 v) => new SerializableVector2(v);

    public override string ToString()
    {
        return $"({x}, {y})";
    }

}

[System.Serializable]
public class SerializableVector3
{
    public float x;
    public float y;
    public float z;

    public SerializableVector3()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
    }

    public SerializableVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public SerializableVector3(Vector3 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }

    public static implicit operator Vector3(SerializableVector3 sv) => new Vector3(sv.x, sv.y, sv.z);
    public static implicit operator SerializableVector3(Vector3 v) => new SerializableVector3(v);

    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }
}