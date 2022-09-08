using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] public float maxHp = 10000;
    [SerializeField] public float currentHp = 10000;

    public EnemyHpBar healthBar;

    private void Start()
    {
        currentHp = maxHp;
        healthBar.setMaxHealth(maxHp);
    }

    public void DecreaseEntityHp(float hpToDecrease)
    {
        currentHp -= hpToDecrease;

        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }

        healthBar.setHealth(currentHp);
    }
}

