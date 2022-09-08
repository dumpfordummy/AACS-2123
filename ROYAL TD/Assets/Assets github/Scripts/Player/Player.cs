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
    float xWidthM = 50f;
    float yHeightM = 25f;
    int typeOfWeapon = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            typeOfWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            typeOfWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            typeOfWeapon = 2;
        }

        animator = GetComponent<Animator>();
        Move();
        if (AtkAnimtimeRemaining > 0)
        {
            AtkAnimtimeRemaining -= Time.deltaTime;
        }

        else if (AtkAnimtimeRemaining <= 0 && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
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

        if (AtkCoolDowntimeRemaining > 0)
        {
            AtkCoolDowntimeRemaining -= Time.deltaTime;
        }
        else if (AtkCoolDowntimeRemaining <= 0)
        {
            ableToAtk = true;
        }

        if (Input.GetMouseButtonDown(1) && ableToAtk)
        {
            ableToAtk = false;
            Attack(typeOfWeapon);
            playerWeaponCover.GetComponent<PlayerWeaponCover>().Attack(typeOfWeapon);
            weapon.GetComponent<Weapon>().Attack(typeOfWeapon);
        }

        float xClamp = Mathf.Clamp(transform.position.x, -xWidthM + 0.5f, xWidthM - 0.5f);
        float yClamp = Mathf.Clamp(transform.position.y, -yHeightM, yHeightM - 1f);
        transform.position = new Vector3(xClamp, yClamp, transform.position.z);
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
            transform.localScale = Vector3.one;
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

    public void Attack(int typeOfWeapon)
    {
        
        AtkCoolDowntimeRemaining = 1.2f;
        Animator anim = gameObject.GetComponentInChildren<Animator>();
        anim.Rebind();
        anim.Update(0f);

        if(typeOfWeapon == 0)
        {
            AtkAnimtimeRemaining = 0.95f;
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
        else if (typeOfWeapon == 1)
        {
            AtkAnimtimeRemaining = 0.55f;
            if (direction == 3)
            {
                SetAnimations(overrideControllers[9]);
            }
            else if (direction == 1)
            {
                SetAnimations(overrideControllers[11]);
            }
            else if (direction == 2)
            {
                transform.localScale = new Vector3(-1, 1, 0);
                SetAnimations(overrideControllers[10]);
            }
            else if (direction == 4)
            {
                transform.localScale = new Vector3(1, 1, 0);
                SetAnimations(overrideControllers[10]);
            }
        }
        else if (typeOfWeapon == 2)
        {
            AtkAnimtimeRemaining = 0.55f;
            if (direction == 3)
            {
                SetAnimations(overrideControllers[12]);
            }
            else if (direction == 1)
            {
                SetAnimations(overrideControllers[14]);
            }
            else if (direction == 2)
            {
                transform.localScale = new Vector3(-1, 1, 0);
                SetAnimations(overrideControllers[13]);
            }
            else if (direction == 4)
            {
                transform.localScale = new Vector3(1, 1, 0);
                SetAnimations(overrideControllers[13]);
            }
        }

    }

    public void SetAnimations(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }
}