using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Loot
{
    // Start is called before the first frame update
    void Start()
    {
        setHp(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (getHp() <= 0)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("WoodResources").GetComponent<woodResources>().addWoodQty(10);
        }
    }
}
