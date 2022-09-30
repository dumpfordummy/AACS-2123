using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public float firstBuildingTime;
    public float firstEnemyWaveTime;
    public int firstEnemyCount;

    public float secondBuildingTime;
    public float secondEnemyWaveTime;
    public int secondEnemyCount;

    public float thirdBuildingTime;
    public float thirdEnemyWaveTime;
    public int thirdEnemyCount;

    public float fourthBuildingTime;
    public float fourthEnemyWaveTime;
    public int fourthEnemyCount;

    public float fifthBuildingTime;
    public float fifthEnemyWaveTime;
    public int fifthEnemyCount;

    public float sixthBuildingTime;
    public float sixthEnemyWaveTime;
    public int sixthEnemyCount;

    private int spawnRegion;
    private float spawnCooldown;
    public float spawnCooldownDuration;
    private Timer timer;

    public int currentWave;

    public GameObject gameCompleteMenu;

    public static int activeEnemyCount;

    public GameObject[] bats;
    public GameObject[] crabs;
    public GameObject[] golem1;
    public GameObject[] golem2;
    public GameObject[] rat;
    public GameObject[] spikedSlime;

    public AudioClip buildingClip;
    public AudioClip enemyClip;
    private AudioSource audioSource;
    public AudioSource winSource;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //activeEnemyCount;
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        if (firstBuildingTime > 0)
        {
            GameObject.Find("CurrentWave").GetComponent<TextMeshProUGUI>().text = "Current Wave: 1/6";
            currentWave = 1;
            firstBuildingTime -= Time.deltaTime;
            timer.DisplayTime(firstBuildingTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.white;
            if (audioSource.clip != buildingClip)
            {
                audioSource.clip = buildingClip;
                audioSource.Play();
            } 
        }
        else if (firstEnemyWaveTime > 0)
        {
            GameObject.Find("CurrentWaveEnemyCount").GetComponent<TextMeshProUGUI>().text = EnemyCounter.GetEnemyCounter().ToString() + " left";
            if (firstEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else if (spawnCooldown <= 0)
                {
                    spawnEnemy(1);
                    firstEnemyCount--;
                    spawnCooldown = spawnCooldownDuration;
                }
            }
            firstEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(firstEnemyWaveTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.red;

            if(EnemyCounter.GetEnemyCounter() == 0)
            {
                firstEnemyWaveTime = 0;
                spawnCooldown = 0;
            }
            if (audioSource.clip != enemyClip)
            {
                audioSource.clip = enemyClip;
                audioSource.Play();
            }
        }
        else if (secondBuildingTime > 0)
        {
            GameObject.Find("CurrentWave").GetComponent<TextMeshProUGUI>().text = "Current Wave: 2/6";
            currentWave = 2;
            secondBuildingTime -= Time.deltaTime;
            timer.DisplayTime(secondBuildingTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.white;
            if (audioSource.clip != buildingClip)
            {
                audioSource.clip = buildingClip;
                audioSource.Play();
            }
        }
        else if (secondEnemyWaveTime > 0)
        {
            GameObject.Find("CurrentWaveEnemyCount").GetComponent<TextMeshProUGUI>().text = EnemyCounter.GetEnemyCounter().ToString() + " left";
            if (secondEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(2);
                    secondEnemyCount--;
                    spawnCooldown = spawnCooldownDuration;
                }
            }
            secondEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(secondEnemyWaveTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.red;

            if (EnemyCounter.GetEnemyCounter() == 0)
            {
                secondEnemyWaveTime = 0;
                spawnCooldown = 0;
            }
            if (audioSource.clip != enemyClip)
            {
                audioSource.clip = enemyClip;
                audioSource.Play();
            }
        }
        else if (thirdBuildingTime > 0)
        {
            GameObject.Find("CurrentWave").GetComponent<TextMeshProUGUI>().text = "Current Wave: 3/6";
            currentWave = 3;
            thirdBuildingTime -= Time.deltaTime;
            timer.DisplayTime(thirdBuildingTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.white;
            if (audioSource.clip != buildingClip)
            {
                audioSource.clip = buildingClip;
                audioSource.Play();
            }
        }
        else if (thirdEnemyWaveTime > 0)
        {
            GameObject.Find("CurrentWaveEnemyCount").GetComponent<TextMeshProUGUI>().text = EnemyCounter.GetEnemyCounter().ToString() + " left";
            if (thirdEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(5);
                    thirdEnemyCount--;
                    spawnCooldown = spawnCooldownDuration;
                }
            }
            thirdEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(thirdEnemyWaveTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.red;

            if (EnemyCounter.GetEnemyCounter() == 0)
            {
                thirdEnemyWaveTime = 0;
                spawnCooldown = 0;
            }
            if (audioSource.clip != enemyClip)
            {
                audioSource.clip = enemyClip;
                audioSource.Play();
            }
        }
        else if (fourthBuildingTime > 0)
        {
            GameObject.Find("CurrentWave").GetComponent<TextMeshProUGUI>().text = "Current Wave: 4/6";
            currentWave = 4;
            fourthBuildingTime -= Time.deltaTime;
            timer.DisplayTime(fourthBuildingTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.white;
            if (audioSource.clip != buildingClip)
            {
                audioSource.clip = buildingClip;
                audioSource.Play();
            }
        }
        else if (fourthEnemyWaveTime > 0)
        {
            GameObject.Find("CurrentWaveEnemyCount").GetComponent<TextMeshProUGUI>().text = EnemyCounter.GetEnemyCounter().ToString() + " left";
            if (fourthEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(6);
                    fourthEnemyCount--;
                    spawnCooldown = spawnCooldownDuration;
                }
            }
            fourthEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(fourthEnemyWaveTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.red;

            if (EnemyCounter.GetEnemyCounter() == 0)
            {
                fourthEnemyWaveTime = 0;
                spawnCooldown = 0;
            }
            if (audioSource.clip != enemyClip)
            {
                audioSource.clip = enemyClip;
                audioSource.Play();
            }
        }
        else if (fifthBuildingTime > 0)
        {
            GameObject.Find("CurrentWave").GetComponent<TextMeshProUGUI>().text = "Current Wave: 5/6";
            currentWave = 5;
            fifthBuildingTime -= Time.deltaTime;
            timer.DisplayTime(fifthBuildingTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.white;
            if (audioSource.clip != buildingClip)
            {
                audioSource.clip = buildingClip;
                audioSource.Play();
            }
        }
        else if (fifthEnemyWaveTime > 0)
        {
            GameObject.Find("CurrentWaveEnemyCount").GetComponent<TextMeshProUGUI>().text = EnemyCounter.GetEnemyCounter().ToString() + " left";
            if (fifthEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(3);
                    fifthEnemyCount--;
                    spawnCooldown = spawnCooldownDuration;
                }
            }
            fifthEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(fifthEnemyWaveTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.red;

            if (EnemyCounter.GetEnemyCounter() == 0)
            {
                fifthEnemyWaveTime = 0;
                spawnCooldown = 0;
            }
            if (audioSource.clip != enemyClip)
            {
                audioSource.clip = enemyClip;
                audioSource.Play();
            }
        }
        else if (sixthBuildingTime > 0)
        {
            GameObject.Find("CurrentWave").GetComponent<TextMeshProUGUI>().text = "Current Wave: 6/6";
            currentWave = 6;
            sixthBuildingTime -= Time.deltaTime;
            timer.DisplayTime(sixthBuildingTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.white;
            if (audioSource.clip != buildingClip)
            {
                audioSource.clip = buildingClip;
                audioSource.Play();
            }
        }
        else if (sixthEnemyWaveTime > 0)
        {
            GameObject.Find("CurrentWaveEnemyCount").GetComponent<TextMeshProUGUI>().text = EnemyCounter.GetEnemyCounter().ToString() + " left";
            if (sixthEnemyCount > 0)
            {
                if (spawnCooldown > 0)
                {
                    spawnCooldown -= Time.deltaTime;
                }
                else
                {
                    spawnEnemy(4);
                    sixthEnemyCount--;
                    spawnCooldown = spawnCooldownDuration;
                }
            }
            sixthEnemyWaveTime -= Time.deltaTime;
            timer.DisplayTime(sixthEnemyWaveTime);
            timer.GetComponent<TextMeshProUGUI>().color = Color.red;

            if (EnemyCounter.GetEnemyCounter() == 0 && audioSource.isPlaying)
            {
                audioSource.Stop();
                winSource.PlayOneShot(winSource.clip);
                gameCompleteMenu.SetActive(true);
            }

            if (audioSource.clip != enemyClip && EnemyCounter.GetEnemyCounter() > 0)
            {
                audioSource.clip = enemyClip;
                audioSource.Play();
            }
        }
        
    }

    public void SkipCurrentBuildingTime()
    {
        switch (currentWave)
        {
            case 1:
                firstBuildingTime = 0;
                break;
            case 2:
                secondBuildingTime = 0;
                break;
            case 3:
                thirdBuildingTime = 0;
                break;
            case 4:
                fourthBuildingTime = 0;
                break;
            case 5:
                fifthBuildingTime = 0;
                break;
            case 6:
                sixthBuildingTime = 0;
                break;
            default:
                break;
        }
    }

    public void spawnEnemy(int n)
    {
        GameObject enemy = FindEnemy(n);
        enemy.SetActive(true);

        spawnRegion = Random.Range(0, 4);

        enemy.GetComponent<EnemyHp>().ResetHp();

        enemy.GetComponent<Enemy>().SetAnimations(0);

        if (spawnRegion == 0)
        {
            //GameObject.Instantiate(enemy, new Vector3(Random.Range(-50, -40) + 0.5f, Random.Range(-15, 25) - 0.5f, 0), new Quaternion());
            enemy.transform.position = new Vector3(Random.Range(-50, -40) + 0.5f, Random.Range(-15, 25) - 0.5f);
        }
        else if (spawnRegion == 1)
        {
            //GameObject.Instantiate(enemy, new Vector3(Random.Range(-50, 40) + 0.5f, Random.Range(-25, -15) + 0.5f, 0), new Quaternion());
            enemy.transform.position = new Vector3(Random.Range(-50, 40) + 0.5f, Random.Range(-25, -15) + 0.5f);
        }
        else if (spawnRegion == 2)
        {
            //GameObject.Instantiate(enemy, new Vector3(Random.Range(40, 50) - 0.5f, Random.Range(-25, 15) + 0.5f, 0), new Quaternion());
            enemy.transform.position = new Vector3(Random.Range(40, 50) - 0.5f, Random.Range(-25, 15) + 0.5f);
        }
        else if (spawnRegion == 3)
        {
            //GameObject.Instantiate(enemy, new Vector3(Random.Range(-40, 50) - 0.5f, Random.Range(15, 25) - 0.5f, 0), new Quaternion());
            enemy.transform.position = new Vector3(Random.Range(-40, 50) - 0.5f, Random.Range(15, 25) - 0.5f);
        }

        enemy.GetComponent<EnemyMovement>().InitializeMovement(); // initialize enemy pathfinding
    }

    private GameObject FindEnemy(int n)
    {
        switch (n)
        {
            case 1:
                for (int i = 0; i < bats.Length; i++)
                {
                    if (!bats[i].activeInHierarchy)
                    {
                        EnemyCounter.IncreaseEnemyCounter();
                        return bats[i];
                    }
                }
                break;
            case 2:
                for (int i = 0; i < crabs.Length; i++)
                {
                    if (!crabs[i].activeInHierarchy)
                    {
                        EnemyCounter.IncreaseEnemyCounter();
                        return crabs[i];
                    }
                }
                break;
            case 3:
                for (int i = 0; i < golem1.Length; i++)
                {
                    if (!golem1[i].activeInHierarchy)
                    {
                        EnemyCounter.IncreaseEnemyCounter();
                        return golem1[i];
                    }
                }
                break;
            case 4:
                for (int i = 0; i < golem2.Length; i++)
                {
                    if (!golem2[i].activeInHierarchy)
                    {
                        EnemyCounter.IncreaseEnemyCounter();
                        return golem2[i];
                    }
                }
                break;
            case 5:
                for (int i = 0; i < rat.Length; i++)
                {
                    if (!rat[i].activeInHierarchy)
                    {
                        EnemyCounter.IncreaseEnemyCounter();
                        return rat[i];
                    }
                }
                break;
            case 6:
                for (int i = 0; i < spikedSlime.Length; i++)
                {
                    if (!spikedSlime[i].activeInHierarchy)
                    {
                        EnemyCounter.IncreaseEnemyCounter();
                        return spikedSlime[i];
                    }
                }
                break;
        }
        return null;
    }
}
