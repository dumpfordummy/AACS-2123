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

    private int weaponDamage = 10;

    private void Awake()
    {
        direction = 3;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

    public void Attack()
    {
        timeRemaining = 1;
        Animator anim = gameObject.GetComponentInChildren<Animator>();
        anim.Rebind();
        anim.Update(0f);

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
        if(loot != null)
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
