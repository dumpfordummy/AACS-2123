using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float hp;

    void Start()
    {
        setHp(500);
    }

    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void setHp(float value)
    {
        this.hp = value;
    }
}
