using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            spawnPlayer();
        }
    }

    public void spawnPlayer()
    {
        GameObject instantiated = GameObject.Instantiate(player);
        CameraFollow.target = instantiated.transform;
    }
}
