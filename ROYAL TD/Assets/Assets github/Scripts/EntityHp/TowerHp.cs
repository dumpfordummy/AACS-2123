using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHp : MonoBehaviour
{
    [SerializeField] private float hp;
    public static bool isInitializing = false;

    public void DecreaseEntityHp(Transform enemy, float hpToDecrease)
    {
        hp -= hpToDecrease;

        if (hp <= 0)
        {
            CleanUp(enemy);
            Destroy(gameObject);
        }
    }

    public void CleanUp(Transform enemy)
    {
        isInitializing = true;
        if (Pathfinding.obstacleList == null)
        {
            // THIS IS THE END OF GAME
            return;
        }
        foreach (PathNode node in Pathfinding.obstacleList)
        {
            GridBase<PathNode>.GetXY(GetComponent<Transform>().position, out int x, out int y);
            if (node.x == x && node.y == y)
            {
                Pathfinding.obstacleList.Remove(node);
                break;
            }
        }

        enemy.gameObject.GetComponent<EnemyMovement>().InitializeMovement();

        GetComponent<TowerAttack>().target = null;
        isInitializing = false;
    }
}
