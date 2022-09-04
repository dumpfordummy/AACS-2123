using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public Transform target;
    public float damage;
    internal bool isAttacking;

    void Start()
    {
        isAttacking = false;
        damage = 0f;
    }

    void Update()
    {
        
    }
    public void attackTarget()
    {
        if (target != null)
        {
            target.GetComponent<EntityHp>().DecreaseEntityHp(damage);
        }
    }
}
