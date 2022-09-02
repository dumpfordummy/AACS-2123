using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    public static GridBase<PathNode> grid = new GridBase<PathNode>(98, 54, 1, new Vector3(-45, -28), (GridBase<PathNode> g, int x, int y) => new PathNode(g, x, y));
}
