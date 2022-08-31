using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameCharacter
{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    public float moveSpeed = 1;
    private float horizontalInput = 0;
    private float verticalInput = 0;
    private Animator animator;
    private void Awake()
    {
        
    }
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
        move();
    }

    public void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1;
            SetAnimations(overrideControllers[3]);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            verticalInput = 0;
            SetAnimations(overrideControllers[0]);
        }
        
        
        if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1;
            SetAnimations(overrideControllers[5]);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            verticalInput = 0;
            SetAnimations(overrideControllers[2]);
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
            SetAnimations(overrideControllers[4]);
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
            SetAnimations(overrideControllers[4]);
            transform.localScale = new Vector3(1, 1, 0);
        }
        else if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)))
        {
            horizontalInput = 0;
            SetAnimations(overrideControllers[1]);
        }

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }

    public void SetAnimations(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }
}
