using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Tile tile { get; protected set; }
    public Directions dir;

    public void Place (Tile target)
    {
        // Make sure previous tile no longer contains this object
        if (tile != null && tile.content == gameObject)
            tile.content = null;

        // Link unit and tile references
        tile = target;

        if (target != null)
            target.content = gameObject;
    }

    public void Match()
    {
        // Moves object to physical location of tile, facing correct direction
        transform.localPosition = tile.center;
        transform.localEulerAngles = dir.ToEuler();
    }
}
