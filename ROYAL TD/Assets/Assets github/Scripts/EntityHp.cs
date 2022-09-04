using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHp : MonoBehaviour
{
    [SerializeField] private float hp;

    public void DecreaseEntityHp(float hpToDecrease)
    {
        hp -= hpToDecrease;

        if (hp <= 0)
        {
            CleanUp();
            Destroy(gameObject);
        }
    }

    public void CleanUp()
    {
        foreach (PathNode node in Pathfinding.obstacleList)
        {
            GridBase<PathNode>.GetXY(GetComponent<Transform>().position, out int x, out int y);
            if (node.x == x && node.y == y)
            {
                Debug.Log("PathNode Removed");
                Pathfinding.obstacleList.Remove(node);
                break;
            }
        }

        GetComponent<TowerAttack>().target = null;
    }
}
