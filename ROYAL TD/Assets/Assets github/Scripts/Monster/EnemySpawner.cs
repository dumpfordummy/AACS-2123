using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float firstBuildingTime;
    public float firstEnemyWaveTime;
    public int firstEnemyCount;
    public GameObject firstEnemy;

    public float secondBuildingTime;
    public float secondEnemyWaveTime;
    public int secondEnemyCount;
    public GameObject secondEnemy;

    public float thirdBuildingTime;
    public float thirdEnemyWaveTime;
    public int thirdEnemyCount;
    public GameObject thirdEnemy;

    public float fourthBuildingTime;
    public float fourthEnemyWaveTime;
    public int fourthEnemyCount;
    public GameObject fourthEnemy;

    public float fifthBuildingTime;
    public float fifthEnemyWaveTime;
    public int fifthEnemyCount;
    public GameObject fifthEnemy;

    public float sixthBuildingTime;
    public float sixthEnemyWaveTime;
    public int sixthEnemyCount;
    public GameObject sixthEnemy;

    private int spawnRegion;
    public float spawnCooldown;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawnCooldown <= 0)
        {
            spawnCooldown = 1f;
            if (firstBuildingTime > 0)
            {
                firstBuildingTime -= 2 * Time.deltaTime;
            }
            else if (firstEnemyWaveTime > 0)
            {
                if (firstEnemyCount > 0)
                {
                    spawnEnemy(firstEnemy);
                    firstEnemyCount--;
                }
                firstEnemyWaveTime -= 2 * Time.deltaTime;
            }
            else if (secondBuildingTime > 0)
            {
                secondBuildingTime -= 2 * Time.deltaTime;
            }
            else if (secondEnemyWaveTime > 0)
            {
                if (secondEnemyCount > 0)
                {
                    spawnEnemy(secondEnemy);
                    secondEnemyCount--;
                }
                secondEnemyWaveTime -= 2 * Time.deltaTime;
            }
            else if (thirdBuildingTime > 0)
            {
                thirdBuildingTime -= 2 * Time.deltaTime;
            }
            else if (thirdEnemyWaveTime > 0)
            {
                if (thirdEnemyCount > 0)
                {
                    spawnEnemy(thirdEnemy);
                    thirdEnemyCount--;
                }
                thirdEnemyWaveTime -= 2 * Time.deltaTime;
            }
            else if (fourthBuildingTime > 0)
            {
                fourthBuildingTime -= 2 * Time.deltaTime;
            }
            else if (fourthEnemyWaveTime > 0)
            {
                if (fourthEnemyCount > 0)
                {
                    spawnEnemy(fourthEnemy);
                    fourthEnemyCount--;
                }
                fourthEnemyWaveTime -= 2 * Time.deltaTime;
            }
            else if (fifthBuildingTime > 0)
            {
                fifthBuildingTime -= 2 * Time.deltaTime;
            }
            else if (fifthEnemyWaveTime > 0)
            {
                if (fifthEnemyCount > 0)
                {
                    spawnEnemy(fifthEnemy);
                    fifthEnemyCount--;
                }
                fifthEnemyWaveTime -= 2 * Time.deltaTime;
            }
            else if (sixthBuildingTime > 0)
            {
                sixthBuildingTime -= 2 * Time.deltaTime;
            }
            else if (sixthEnemyWaveTime > 0)
            {
                if (sixthEnemyCount > 0)
                {
                    spawnEnemy(sixthEnemy);
                    sixthEnemyCount--;
                }
                sixthEnemyWaveTime -= 2 * Time.deltaTime;
            }
        }
        else
            spawnCooldown -= Time.deltaTime;
    }

    void spawnEnemy(GameObject enemy)
    {
        spawnRegion = Random.Range(0, 4);
        if (spawnRegion == 0)
        {
            GameObject.Instantiate(enemy, new Vector3(Random.Range(-50, -40) + 0.5f, Random.Range(-15, 25) - 0.5f, 0), new Quaternion());
        }
        else if (spawnRegion == 1)
        {
            GameObject.Instantiate(enemy, new Vector3(Random.Range(-50, 40) + 0.5f, Random.Range(-25, -15) + 0.5f, 0), new Quaternion());
        }
        else if (spawnRegion == 2)
        {
            GameObject.Instantiate(enemy, new Vector3(Random.Range(40, 50) - 0.5f, Random.Range(-25, 15) + 0.5f, 0), new Quaternion());
        }
        else if (spawnRegion == 3)
        {
            GameObject.Instantiate(enemy, new Vector3(Random.Range(-40, 50) - 0.5f, Random.Range(15, 25) - 0.5f, 0), new Quaternion());
        }


    }
}