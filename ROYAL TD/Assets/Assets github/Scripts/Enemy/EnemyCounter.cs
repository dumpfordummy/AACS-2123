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
        if(enemyCounter != 0)
            enemyCounter--;
    }

    public static int GetEnemyCounter()
    {
        return enemyCounter;
    }

    public static void ResetEnemyCounter()
    {
        enemyCounter = 0;
    }
}
