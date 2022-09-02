using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EnemyMovement : MonoBehaviour
{
    private List<Vector3> waypoint;
    private Pathfinding pathfinding;
    public float moveSpeed = 1f;
    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        pathfinding = new Pathfinding(GridHandler.grid);
        waypoint = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            waypoint.Clear();
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int mouseX, out int mouseY);
            pathfinding.GetGrid().GetXY(transform.position, out int initX, out int initY);

            if (mouseX - initX == 0 && mouseY - initY == 0)
                return;

            List<PathNode> paths = pathfinding.FindPath(initX, initY, mouseX, mouseY);

            foreach (PathNode path in paths)
            {
                waypoint.Add(pathfinding.GetGrid().GetWorldPosition(path.x, path.y) + new Vector3(.5f, .5f));
            }
        }
        followPath();
    }

    private void followPath()
    {
        if (waypoint.Count == 0)
            return;
        if (waypointIndex < waypoint.Count)
        {
            Vector3 finalPosition = Vector3.MoveTowards(transform.position, waypoint[waypointIndex], moveSpeed * Time.deltaTime);
            transform.position = finalPosition;

            if (transform.position == waypoint[waypointIndex])
            {
                waypointIndex++;

                if (waypointIndex == waypoint.Count)
                {
                    waypointIndex = 0;
                    waypoint.Clear();
                }
            }

        }
    }
}