using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    private Animator animator;
    public Transform target;
    public float attackSpeed = 1;
    public float damage = 10f;
    public bool isAttacking = false;
    public bool isAllive = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isAllive)
        {
            if (target == null)
            {
                isAttacking = false;
                SetAnimations(0);
            }
            else if (target != null)
            {
                SetAnimations(1);
            }
        }

    }

    public void attackTarget()
    {

        if (target != null && isAllive)
        {
            target.GetComponent<TowerHp>().DecreaseEntityHp(GetComponent<Transform>(), damage);
        }
    }

    public void SetAnimations(int i)
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = overrideControllers[i];
    }
}
