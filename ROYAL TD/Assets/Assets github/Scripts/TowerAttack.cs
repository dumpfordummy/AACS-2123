using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public Transform target;
    public float attackSpeed = 1;
    public float damage = 10f;
    private EnemyHp getHp;



    public void attackTarget()
    {
        if(target != null)
        {
            changeHp(damage);
        }
    }

    private void changeHp(float damage)
    {
        getHp = target.GetComponent<EnemyHp>();
        getHp.hp -= damage;
    }
}
