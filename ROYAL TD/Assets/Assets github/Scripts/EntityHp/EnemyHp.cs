using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private float hp;

    public void DecreaseEntityHp(float hpToDecrease)
    {
        hp -= hpToDecrease;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

