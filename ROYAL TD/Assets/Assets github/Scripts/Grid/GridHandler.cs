using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    public static GridBase<PathNode> grid = new GridBase<PathNode>(98, 54, 1, new Vector3(-45, -28), (GridBase<PathNode> g, int x, int y) => new PathNode(g, x, y));

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }
}
