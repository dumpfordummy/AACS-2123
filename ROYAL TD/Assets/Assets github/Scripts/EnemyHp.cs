using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int hp;

    void Start()
    {
        setHp(100);
    }

    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void setHp(int value)
    {
        this.hp = value;
    }
}
