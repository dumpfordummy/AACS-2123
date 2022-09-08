using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private float currentHp;
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

        currentHp -= hpToDecrease;

        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }



        healthBar.setHealth(currentHp);
    }
}

