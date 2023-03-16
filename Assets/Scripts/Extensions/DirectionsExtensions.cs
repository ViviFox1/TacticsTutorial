using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DirectionsExtensions
{
    public static Directions GetDirection(this Tile t1, Tile t2)
    {
        // Gives direction of tile 2 in relation to tile 1. Prioritizes "further" direction, defaults to W
        // Ex: t1 = (0,0). t2 = (2,1) - faces East. t2 = (1,2) - faces N
        if (t1.pos.y < t2.pos.y && Mathf.Abs(t1.pos.y - t2.pos.y) >= Mathf.Abs(t1.pos.x - t2.pos.x))
            return Directions.North;
        if (t1.pos.x < t2.pos.x && Mathf.Abs(t1.pos.x - t2.pos.x) >= Mathf.Abs(t1.pos.y - t2.pos.y))
            return Directions.East;
        if (t1.pos.y > t2.pos.y && Mathf.Abs(t1.pos.y - t2.pos.y) >= Mathf.Abs(t1.pos.x - t2.pos.x))
            return Directions.South;
        return Directions.West;
    }
    public static Vector3 ToEuler(this Directions d)
    {
        // Converts direction to Vector 3
        return new Vector3(0, (int)d * 90, 0);
    }
}
