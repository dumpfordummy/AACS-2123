using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] public float maxHp = 10000;
    [SerializeField] public float currentHp = 10000;
    public EnemyHpBar healthBar;
    private Enemy enemy;

    private void Start()
    {
        currentHp = maxHp;
        healthBar.setMaxHealth(maxHp);
        enemy = GetComponent<Enemy>();
    }

    public void DecreaseEntityHp(float hpToDecrease)
    {
        if(enemy.target == null)
        {
            return;
        }

        currentHp -= hpToDecrease;

        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }



        healthBar.setHealth(currentHp);
    }
}

