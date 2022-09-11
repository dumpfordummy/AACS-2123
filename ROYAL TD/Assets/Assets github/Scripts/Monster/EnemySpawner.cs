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
    private Timer timer;

    // Update is called once per frame
    void Update()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        if (firstBuildingTime > 0)
        {
            firstBuildingTime -= Time.deltaTime;
            timer.DisplayTime(firstBuildingTime);
        }
        else if (firstEnemyWaveTime > 0)
        {
            if (firstEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(firstEnemy);
                    firstEnemyCount--;
                    spawnCooldown = 1f;
                }
            }
            firstEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(firstEnemyWaveTime);
        }
        else if (secondBuildingTime > 0)
        {
            secondBuildingTime -= Time.deltaTime;
            timer.DisplayTime(secondBuildingTime);
        }
        else if (secondEnemyWaveTime > 0)
        {
            if (secondEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(secondEnemy);
                    secondEnemyCount--;
                    spawnCooldown = 1f;
                }
            }
            secondEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(secondEnemyWaveTime);
        }
        else if (thirdBuildingTime > 0)
        {
            thirdBuildingTime -= Time.deltaTime;
            timer.DisplayTime(thirdBuildingTime);
        }
        else if (thirdEnemyWaveTime > 0)
        {
            if (thirdEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(thirdEnemy);
                    thirdEnemyCount--;
                    spawnCooldown = 1f;
                }
            }
            thirdEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(thirdEnemyWaveTime);
        }
        else if (fourthBuildingTime > 0)
        {
            fourthBuildingTime -= Time.deltaTime;
            timer.DisplayTime(fourthBuildingTime);
        }
        else if (fourthEnemyWaveTime > 0)
        {
            if (fourthEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(fourthEnemy);
                    fourthEnemyCount--;
                    spawnCooldown = 1f;
                }
            }
            fourthEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(fourthEnemyWaveTime);
        }
        else if (fifthBuildingTime > 0)
        {
            fifthBuildingTime -= Time.deltaTime;
            timer.DisplayTime(fifthBuildingTime);
        }
        else if (fifthEnemyWaveTime > 0)
        {
            if (fifthEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(fifthEnemy);
                    fifthEnemyCount--;
                    spawnCooldown = 1f;
                }
            }
            fifthEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(fifthEnemyWaveTime);
        }
        else if (sixthBuildingTime > 0)
        {
            sixthBuildingTime -= Time.deltaTime;
            timer.DisplayTime(sixthBuildingTime);
        }
        else if (sixthEnemyWaveTime > 0)
        {
            if (sixthEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(sixthEnemy);
                    sixthEnemyCount--;
                    spawnCooldown = 1f;
                }
            }
            sixthEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(sixthEnemyWaveTime);
        }
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
