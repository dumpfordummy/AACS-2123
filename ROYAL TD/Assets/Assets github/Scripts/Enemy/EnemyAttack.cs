using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Enemy parent;
    private float nextFireTime = 0.0f;

    void Start()
    {
        parent = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Defense"))
        {
            if (other.gameObject.name == "StoneWall(Clone)" && !IsPropInWaypoint(other))
            {
                return;
            }

            if (IsPropInWaypoint(other))
            {
                GetComponentInParent<EnemyMovement>().SetWaypoint();
                return;
            }
            parent.target = other.transform;
        }
    }

    private bool IsPropInWaypoint(Collider2D other)
    {
        GridBase<PathNode>.GetXY(other.transform.position, out int x, out int y);

        foreach (Vector3 position in GetComponentInParent<EnemyMovement>().waypoint)
        {
            GridBase<PathNode>.GetXY(position, out int waypointX, out int waypointY);
            if (x == waypointX && y == waypointY)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Defense"))
        {
            return;
        }

        if (other.gameObject.name == "StoneWall(Clone)" && !IsPropInWaypoint(other))
        {
            return;
        }

        parent.target = other.transform;
        parent.GetComponent<Enemy>().isAttacking = true;
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1 / parent.attackSpeed;
            parent.attackTarget();
        }

    }
}
