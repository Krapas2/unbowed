using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorSwizzlingExtensionMethods
{
    // 3D to 2D 

    public static Vector2 XY(this Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }

    public static Vector2 XZ(this Vector3 v)
    {
        return new Vector2(v.x, v.z);
    }

    public static Vector2 YX(this Vector3 v)
    {
        return new Vector2(v.y, v.x);
    }

    public static Vector2 YZ(this Vector3 v)
    {
        return new Vector2(v.y, v.z);
    }

    public static Vector2 ZX(this Vector3 v)
    {
        return new Vector2(v.z, v.x);
    }

    public static Vector2 ZY(this Vector3 v)
    {
        return new Vector2(v.z, v.y);
    }

    // 3D to 3D

    public static Vector3 XYZ(this Vector3 v)
    {
        return new Vector3(v.x, v.y, v.z);
    }

    public static Vector3 OYZ(this Vector3 v)
    {
        return new Vector3(0f, v.y, v.z);
    }

    public static Vector3 XOZ(this Vector3 v)
    {
        return new Vector3(v.x, 0f, v.z);
    }

    public static Vector3 XYO(this Vector3 v)
    {
        return new Vector3(v.x, v.y, 0f);
    }

    public static Vector3 XZY(this Vector3 v)
    {
        return new Vector3(v.x, v.z, v.y);
    }

    public static Vector3 OZY(this Vector3 v)
    {
        return new Vector3(0f, v.z, v.y);
    }

    public static Vector3 XOY(this Vector3 v)
    {
        return new Vector3(v.x, 0f, v.y);
    }

    public static Vector3 XZO(this Vector3 v)
    {
        return new Vector3(v.x, v.z, 0f);
    }

    public static Vector3 YXZ(this Vector3 v)
    {
        return new Vector3(v.y, v.x, v.z);
    }

    public static Vector3 OXZ(this Vector3 v)
    {
        return new Vector3(0f, v.x, v.z);
    }

    public static Vector3 YOZ(this Vector3 v)
    {
        return new Vector3(v.y, 0f, v.z);
    }

    public static Vector3 YXO(this Vector3 v)
    {
        return new Vector3(v.y, v.x, 0f);
    }

    public static Vector3 YZX(this Vector3 v)
    {
        return new Vector3(v.y, v.z, v.x);
    }

    public static Vector3 OZX(this Vector3 v)
    {
        return new Vector3(0f, v.z, v.x);
    }

    public static Vector3 YOX(this Vector3 v)
    {
        return new Vector3(v.y, 0f, v.x);
    }

    public static Vector3 YZO(this Vector3 v)
    {
        return new Vector3(v.y, v.z, 0f);
    }

    public static Vector3 ZXY(this Vector3 v)
    {
        return new Vector3(v.z, v.x, v.y);
    }

    public static Vector3 OXY(this Vector3 v)
    {
        return new Vector3(0f, v.x, v.y);
    }

    public static Vector3 ZOY(this Vector3 v)
    {
        return new Vector3(v.z, 0f, v.y);
    }

    public static Vector3 ZXO(this Vector3 v)
    {
        return new Vector3(v.z, v.x, 0f);
    }

    public static Vector3 ZYX(this Vector3 v)
    {
        return new Vector3(v.z, v.y, v.x);
    }

    public static Vector3 OYX(this Vector3 v)
    {
        return new Vector3(0f, v.y, v.x);
    }

    public static Vector3 ZOX(this Vector3 v)
    {
        return new Vector3(v.z, 0f, v.x);
    }

    public static Vector3 ZYO(this Vector3 v)
    {
        return new Vector3(v.z, v.y, 0f);
    }

    public static Vector3 XOO(this Vector3 v)
    {
        return new Vector3(v.x, 0f, 0f);
    }

    public static Vector3 OXO(this Vector3 v)
    {
        return new Vector3(0f, v.x, 0f);
    }

    public static Vector3 OOX(this Vector3 v)
    {
        return new Vector3(0f, 0f, v.x);
    }

    public static Vector3 YOO(this Vector3 v)
    {
        return new Vector3(v.y, 0f, 0f);
    }

    public static Vector3 OYO(this Vector3 v)
    {
        return new Vector3(0f, v.y, 0f);
    }

    public static Vector3 OOY(this Vector3 v)
    {
        return new Vector3(0f, 0f, v.y);
    }

    public static Vector3 ZOO(this Vector3 v)
    {
        return new Vector3(v.z, 0f, 0f);
    }

    public static Vector3 OZO(this Vector3 v)
    {
        return new Vector3(0f, v.z, 0f);
    }

    public static Vector3 OOZ(this Vector3 v)
    {
        return new Vector3(0f, 0f, v.z);
    }
}
