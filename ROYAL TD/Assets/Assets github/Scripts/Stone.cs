using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Loot
{

    // Start is called before the first frame update
    void Start()
    {
        setHp(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Stone"));
        }
    }
}
