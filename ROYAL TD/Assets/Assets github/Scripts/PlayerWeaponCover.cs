using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCover : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    private Animator animator;
    private float timeRemaining;
    private int direction;

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
        Attack();
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            SetAnimations(overrideControllers[0]);
        }
    }

    public void Attack()
    {
        if (!Input.GetKey(KeyCode.Alpha2))
        {
            return;
        }

        timeRemaining = 1;
        Animator anim = gameObject.GetComponentInChildren<Animator>();
        anim.Rebind();
        anim.Update(0f);

        if (direction == 2)
        {
            SetAnimations(overrideControllers[2]);
            GetComponent<SpriteRenderer>().sortingOrder = 3;
        }

        if (direction == 3)
        {
            SetAnimations(overrideControllers[1]);
            GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        if (direction == 4)
        {
            SetAnimations(overrideControllers[2]);
            GetComponent<SpriteRenderer>().sortingOrder = 3;
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

}
