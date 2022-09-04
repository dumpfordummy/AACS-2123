using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private Enemy parent;
    private float nextFireTime = 0.0f;

    void Start()
    {
        parent = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Defense"))
        {
            parent.target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Defense"))
        {
            parent.target = null;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (parent.target == null)
        {
            parent.target = other.transform;
        }

        if (!other.gameObject.CompareTag("Defense"))
        {
            parent.target = null;
            return;
        }



        if (other.gameObject.CompareTag("Defense") && Time.time > nextFireTime)
        {
            parent.GetComponent<Enemy>().isAttacking = true;
            nextFireTime = Time.time + 1 / parent.attackSpeed;
            parent.attackTarget();
        }
    }
}
