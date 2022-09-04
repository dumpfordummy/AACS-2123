using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    private Animator animator;
    private float timeRemaining;
    private int direction;
    public bool ableToAtk = true;
    private float nextFireTime;

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

        if (!ableToAtk && (Time.time > nextFireTime))
        {
            nextFireTime = Time.time + 1f;
            ableToAtk = true;
        }

        Attack();
    }

    public void Attack()
    {
        if (!Input.GetKey(KeyCode.Alpha2) || !ableToAtk)
        {
            return;
        }

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

        ableToAtk = false;
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
        if (other.gameObject.CompareTag("Stone") && Input.GetKey(KeyCode.Alpha2) && ableToAtk)
        {
            other.GetComponent<Stone>().receiveDamage(30);
        }

        if (other.gameObject.CompareTag("Tree") && Input.GetKey(KeyCode.Alpha2) && ableToAtk)
        {
            other.GetComponent<Tree>().receiveDamage(30);
        }
    }
}
