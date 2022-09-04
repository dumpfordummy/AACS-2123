using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHp : MonoBehaviour
{
    public float hp;

    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DecreaseEntityHp(float hpToDecrease)
    {
        hp -= hpToDecrease;
    }
}
