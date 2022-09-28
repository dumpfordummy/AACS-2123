using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<Vector3> waypoint;
    public Pathfinding pathfinding;
    public Enemy enemy;
    public float moveSpeed = 1f;
    private int waypointIndex = 0;
    Vector3 initialScale;
    Vector3 townHallPosition;

    void Start()
    {
        InitializeMovement();
    }

    void FixedUpdate()
    {
        if (!TowerHp.isInitializing && gameObject.GetComponent<Enemy>().isAllive)
        {
            followPath();
        }
    }

    public void InitializeMovement()
    {
        townHallPosition = GameObject.Find("TownHall").GetComponent<Transform>().position;
        pathfinding = GridHandler.pathInit;
        enemy = GetComponent<Enemy>();
        waypoint = new List<Vector3>();
        initialScale = transform.localScale;
        enemy.isAttacking = false;
        SetWaypoint();
    }

    public void SetWaypoint()
    {
        waypointIndex = 0;
        waypoint.Clear();
        
        GridBase<PathNode>.GetXY(townHallPosition, out int endX, out int endY);
        GridBase<PathNode>.GetXY(transform.position, out int initX, out int initY);

        List<PathNode> paths = pathfinding.FindPath(initX, initY, endX, endY);

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

        if (waypoint[waypointIndex].x - transform.position.x > 0)
        {
            transform.localScale = initialScale;
        }
        else
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }

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