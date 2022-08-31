using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
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
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            SetAnimations(overrideControllers[0]);
        }
        Attack();
    }

    public void Attack()
    {
        if (Input.GetKey(KeyCode.Alpha2) && direction == 3)
        {
            timeRemaining = 1;
            SetAnimations(overrideControllers[1]);
        }

        if (Input.GetKey(KeyCode.Alpha2) && direction == 1)
        {
            timeRemaining = 1;
            SetAnimations(overrideControllers[3]);
        }

        if (Input.GetKey(KeyCode.Alpha2) && direction == 2)
        {
            timeRemaining = 1;
            SetAnimations(overrideControllers[2]);
        }

        if (Input.GetKey(KeyCode.Alpha2) && direction == 4)
        {
            timeRemaining = 1;
            SetAnimations(overrideControllers[2]);
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
