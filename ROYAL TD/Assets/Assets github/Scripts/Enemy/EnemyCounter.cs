using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private static int enemyCounter = 0;

    public static void IncreaseEnemyCounter()
    {
        enemyCounter++;
    }

    public static void DecreaseEnemyCounter()
    {
        enemyCounter--;
    }

    public static int GetEnemyCounter()
    {
        return enemyCounter;
    }
}
