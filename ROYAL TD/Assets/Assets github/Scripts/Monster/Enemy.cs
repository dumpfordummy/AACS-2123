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

    private void Update()
    {
        animator = GetComponent<Animator>();
        if (target == null)
        {
            isAttacking = false;
            SetAnimations(0);
        }
        else
        {
            SetAnimations(1);
            Animator anim = gameObject.GetComponentInChildren<Animator>();
            anim.Rebind();
            anim.Update(0f);
        }
        
    }

    public void attackTarget()
    {

        if (target != null)
        {
            target.GetComponent<TowerHp>().DecreaseEntityHp(GetComponent<Transform>(), damage);
        }
    }

    public void SetAnimations(int i)
    {
        animator.runtimeAnimatorController = overrideControllers[i];
    }
}
