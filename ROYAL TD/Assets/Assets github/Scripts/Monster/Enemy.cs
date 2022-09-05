using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float attackSpeed = 1;
    public float damage = 10f;
    public bool isAttacking = false;

    private void Update()
    {
        Debug.Log(isAttacking);
        if (target == null)
        {
            isAttacking = false;
        }
    }

    public void attackTarget()
    {
        if (target != null)
        {
            target.GetComponent<TowerHp>().DecreaseEntityHp(GetComponent<Transform>(), damage);
        }
    }
}
