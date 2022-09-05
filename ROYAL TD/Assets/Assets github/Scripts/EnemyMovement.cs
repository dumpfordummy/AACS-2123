using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private List<Vector3> waypoint;
    public Pathfinding pathfinding;
    public Enemy enemy;
    public float moveSpeed = 1f;
    private int waypointIndex = 0;
    

    void Start()
    {
        pathfinding = new Pathfinding(GridHandler.grid);
        enemy = GetComponent<Enemy>();
        waypoint = new List<Vector3>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            InitializeMovement();
        }
        if (!TowerHp.isInitializing)
        {
            followPath();
        }
    }

    public void InitializeMovement()
    {
        enemy.isAttacking = false;
        waypoint.Clear();
        Vector3 mouseWorldPosition = GridBase<PathNode>.GetMouseWorldPosition();
        GridBase<PathNode>.GetXY(mouseWorldPosition, out int mouseX, out int mouseY);
        GridBase<PathNode>.GetXY(transform.position, out int initX, out int initY);

        List<PathNode> paths = pathfinding.FindPath(initX, initY, mouseX, mouseY);

        if (paths == null)
            return;

        foreach (PathNode path in paths)
        {
            if (path.x == initX && path.y == initY)
                continue;
            waypoint.Add(pathfinding.GetGrid().GetWorldPosition(path.x, path.y) + new Vector3(.5f, .5f));
        }
    }

    private void followPath()
    {
        if (waypoint.Count == 0 || waypointIndex >= waypoint.Count || enemy.isAttacking)
            return;

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