using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameCharacter
{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    private Animator animator;
    private float AtkAnimtimeRemaining;
    public float moveSpeed = 1;
    private float horizontalInput = 0;
    private float verticalInput = 0;
    private int direction;
    private bool ableToAtk = true;
    private float nextFireTime;
    public GameObject weapon;
    public GameObject playerWeaponCover;
    private float AtkCoolDowntimeRemaining;

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
        Move();
        if (AtkAnimtimeRemaining > 0)
        {
            AtkAnimtimeRemaining -= Time.deltaTime;
        }
        else if (AtkAnimtimeRemaining <= 0)
        {
            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) == false)
            {
                if (direction == 3)
                {
                    SetAnimations(overrideControllers[0]);
                }
                else if (direction == 1)
                {
                    SetAnimations(overrideControllers[2]);
                }
                else if (direction == 2)
                {
                    SetAnimations(overrideControllers[1]);
                }
                else if (direction == 4)
                {
                    SetAnimations(overrideControllers[1]);
                }
            }
        }

        if (AtkCoolDowntimeRemaining > 0)
        {
            AtkCoolDowntimeRemaining -= Time.deltaTime;
        }
        else if (AtkCoolDowntimeRemaining <= 0)
        {
            ableToAtk = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && ableToAtk)
        {
            ableToAtk = false;
            Attack();
            playerWeaponCover.GetComponent<PlayerWeaponCover>().Attack();
            weapon.GetComponent<Weapon>().Attack();
        }
        
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1;
            SetAnimations(overrideControllers[3]);
            GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>().setDirection(3);
            GameObject.FindGameObjectWithTag("PlayerWeaponCover").GetComponent<PlayerWeaponCover>().setDirection(3);
            direction = 3;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            verticalInput = 0;
            SetAnimations(overrideControllers[0]);
            GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>().setDirection(3);
            GameObject.FindGameObjectWithTag("PlayerWeaponCover").GetComponent<PlayerWeaponCover>().setDirection(3);
            direction = 3;
        }

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1;
            SetAnimations(overrideControllers[5]);
            GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>().setDirection(1);
            GameObject.FindGameObjectWithTag("PlayerWeaponCover").GetComponent<PlayerWeaponCover>().setDirection(1);
            direction = 1;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            verticalInput = 0;
            SetAnimations(overrideControllers[2]);
            GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>().setDirection(1);
            GameObject.FindGameObjectWithTag("PlayerWeaponCover").GetComponent<PlayerWeaponCover>().setDirection(1);
            direction = 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
            SetAnimations(overrideControllers[4]);
            transform.localScale = new Vector3(-1, 1, 0);
            GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>().setDirection(2);
            GameObject.FindGameObjectWithTag("PlayerWeaponCover").GetComponent<PlayerWeaponCover>().setDirection(2);
            direction = 2;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            horizontalInput = 0;
            SetAnimations(overrideControllers[1]);
            GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>().setDirection(2);
            GameObject.FindGameObjectWithTag("PlayerWeaponCover").GetComponent<PlayerWeaponCover>().setDirection(2);
            direction = 2;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
            SetAnimations(overrideControllers[4]);
            transform.localScale = new Vector3(1, 1, 0);
            GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>().setDirection(4);
            GameObject.FindGameObjectWithTag("PlayerWeaponCover").GetComponent<PlayerWeaponCover>().setDirection(4);
            direction = 4;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            horizontalInput = 0;
            SetAnimations(overrideControllers[1]);
            GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>().setDirection(4);
            GameObject.FindGameObjectWithTag("PlayerWeaponCover").GetComponent<PlayerWeaponCover>().setDirection(4);
            direction = 4;
        }

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }

    public void Attack()
    {
        AtkAnimtimeRemaining = 0.9f;
        AtkCoolDowntimeRemaining = 1.2f;
        Animator anim = gameObject.GetComponentInChildren<Animator>();
        anim.Rebind();
        anim.Update(0f);

        if (direction == 3)
        {
            SetAnimations(overrideControllers[6]);
        }
        else if (direction == 1)
        {
            SetAnimations(overrideControllers[8]);
        }
        else if (direction == 2)
        {
            transform.localScale = new Vector3(-1, 1, 0);
            SetAnimations(overrideControllers[7]);
        }
        else if (direction == 4)
        {
            transform.localScale = new Vector3(1, 1, 0);
            SetAnimations(overrideControllers[7]);
        }
    }

    public void setAttackDuration()
    {

    }

    public void SetAnimations(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }
}
