using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public Transform target;
    public float attackSpeed = 1;
    public float damage = 10f;
    private EntityHp getHp;

    public void attackTarget()
    {
        if(target != null)
        {
            updateEnemyHp(damage);
        }
    }

    private void updateEnemyHp(float damage)
    {
        target.GetComponent<EntityHp>().DecreaseEntityHp(damage);
    }
}
