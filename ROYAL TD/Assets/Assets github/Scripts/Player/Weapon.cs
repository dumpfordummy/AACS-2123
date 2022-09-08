using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    private Animator animator;
    private float timeRemaining;
    private int direction;
    private float nextFireTime;
    private Collider2D loot;
    private int weaponDamage;

    private void Awake()
    {
        weaponDamage = 50;
        direction = 3;
    }

    void Update()
    {
        animator = GetComponent<Animator>();
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            SetAnimations(overrideControllers[0]);
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            SetAnimations(overrideControllers[0]);
        }
    }

    public void Attack(int typeOfWeapon)
    {
        
        Animator anim = gameObject.GetComponentInChildren<Animator>();
        anim.Rebind();
        anim.Update(0f);

        if (typeOfWeapon == 0)
        {
            timeRemaining = 0.95f;
            if (direction == 1)
            {
                SetAnimations(overrideControllers[3]);
                GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (direction == 2)
            {
                SetAnimations(overrideControllers[2]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            else if (direction == 3)
            {
                SetAnimations(overrideControllers[1]);
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            else if (direction == 4)
            {
                SetAnimations(overrideControllers[2]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
        }
        else if (typeOfWeapon == 1)
        {
            timeRemaining = 0.55f;
            if (direction == 1)
            {
                SetAnimations(overrideControllers[6]);
                GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (direction == 2)
            {
                SetAnimations(overrideControllers[5]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            else if (direction == 3)
            {
                SetAnimations(overrideControllers[4]);
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            else if (direction == 4)
            {
                SetAnimations(overrideControllers[5]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
        }
        else if (typeOfWeapon == 2)
        {
            timeRemaining = 0.55f;
            if (direction == 1)
            {
                SetAnimations(overrideControllers[9]);
                GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (direction == 2)
            {
                SetAnimations(overrideControllers[8]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            else if (direction == 3)
            {
                SetAnimations(overrideControllers[7]);
                GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            else if (direction == 4)
            {
                SetAnimations(overrideControllers[8]);
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
        }

        if (loot != null)
        {
            loot.GetComponent<Loot>().receiveDamage(weaponDamage);
        }

    }

    public void SetAnimations(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }

    public void setDirection(int direction)
    {
        this.direction = direction;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Stone"))
        {
            loot = other;
        }

        if (other.gameObject.CompareTag("Tree"))
        {
            loot = other;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        loot = null;
    }
}
