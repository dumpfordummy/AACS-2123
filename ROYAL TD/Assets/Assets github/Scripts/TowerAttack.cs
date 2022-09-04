using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public Transform target;
    public float attackSpeed = 1;
    public int damage = 10;
    private EnemyHp getHp;

    private void Update()
    {
        attackTarget();
    }

    private void attackTarget()
    {
        if(target != null)
        {
            changeHp(damage);
        }
    }

    private void changeHp(int damage)
    {
        getHp = target.GetComponent<EnemyHp>();
        getHp.hp -= damage;
    }
}
