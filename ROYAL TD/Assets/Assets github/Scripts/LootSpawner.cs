using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    public GameObject stone;
    public GameObject tree;
    float timeRemaining;
    public int stoneCount;
    public int treeCount;
    int spawnRegion;

    void Update()
    {
        if (timeRemaining <= 0)
        {
            timeRemaining = 1f;
            if (stoneCount <= 100)
            {
                spawnStone();
            }
            
            if (treeCount <= 100)
            {
                spawnTree();
            }
            
        }
        else
            timeRemaining -= Time.deltaTime;
    }

    void spawnStone()
    {
        spawnRegion = Random.Range(0, 4);
        if (spawnRegion == 0)
        {
            objectSpawner<GameObject>(stone, new Vector3(Random.Range(-50, -40) + 0.5f, Random.Range(-15, 25) - 0.5f, 0), new Quaternion());
        }
        else if (spawnRegion == 1)
        {
            objectSpawner<GameObject>(stone, new Vector3(Random.Range(-50, 40) + 0.5f, Random.Range(-25, -15) + 0.5f, 0), new Quaternion());
        }
        else if (spawnRegion == 2)
        {
            objectSpawner<GameObject>(stone, new Vector3(Random.Range(40, 50) - 0.5f, Random.Range(-25, 15) + 0.5f, 0), new Quaternion());
        }
        else if (spawnRegion == 3)
        {
            objectSpawner<GameObject>(stone, new Vector3(Random.Range(-40, 50) - 0.5f, Random.Range(15, 25) - 0.5f, 0), new Quaternion());
        }
        
        stoneCount++;
    }

    void spawnTree()
    {
        spawnRegion = Random.Range(0, 4);
        if (spawnRegion == 0)
        {
            objectSpawner<GameObject>(tree, new Vector3(Random.Range(-50, -40) + 0.5f, Random.Range(-15, 25) - 0.5f, 0), new Quaternion());
        }
        else if (spawnRegion == 1)
        {
            objectSpawner<GameObject>(tree, new Vector3(Random.Range(-50, 40) + 0.5f, Random.Range(-25, -15) + 0.5f, 0), new Quaternion());
        }
        else if (spawnRegion == 2)
        {
            objectSpawner<GameObject>(tree, new Vector3(Random.Range(40, 50) - 0.5f, Random.Range(-25, 15) + 0.5f, 0), new Quaternion());
        }
        else if (spawnRegion == 3)
        {
            objectSpawner<GameObject>(tree, new Vector3(Random.Range(-40, 50) - 0.5f, Random.Range(15, 25) - 0.5f, 0), new Quaternion());
        }
        treeCount++;
    }

    T objectSpawner<T>(T original, Vector3 position, Quaternion rotation) where T : Object
    {
        PathNode currentNode;
        GridBase<PathNode>.GetXY(position, out int posX, out int posY);
        currentNode = Pathfinding.GetNode(posX, posY);
        Pathfinding.obstacleList.Add(currentNode);
        return (T)Instantiate((Object)original, position, rotation);
    }
}
