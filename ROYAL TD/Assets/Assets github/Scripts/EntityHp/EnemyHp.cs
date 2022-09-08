using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] public float hp;

    public void DecreaseEntityHp(float hpToDecrease)
    {
        hp -= hpToDecrease;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

