using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    private Animator animator;
    private float timeRemaining;
    private int direction;
    private Collider2D loot;
    private Collider2D enemy;
    private int weaponDamage;
    private int typeOfWeapon;
    [SerializeField] private AudioSource sound1;
    [SerializeField] private AudioSource sound2;
    [SerializeField] private AudioSource sound3;
    public int damageOfHammer;
    public int damageOfSword;
    public int damageOfSycthe;
    private bool isOneHitKill;

    private void Awake()
    {
        isOneHitKill = false;
        weaponDamage = 50;
        direction = 3;
    }

    void Update()
    {
        if (typeOfWeapon == 0)
        {
            GameObject.FindGameObjectWithTag("HammerFrame").GetComponent<Image>().color = new Color32(0, 225, 225, 255);
            GameObject.FindGameObjectWithTag("SwordFrame").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.FindGameObjectWithTag("SyctheFrame").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (typeOfWeapon == 1)
        {
            GameObject.FindGameObjectWithTag("HammerFrame").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.FindGameObjectWithTag("SwordFrame").GetComponent<Image>().color = new Color32(0, 225, 225, 255);
            GameObject.FindGameObjectWithTag("SyctheFrame").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (typeOfWeapon == 2)
        {
            GameObject.FindGameObjectWithTag("HammerFrame").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.FindGameObjectWithTag("SwordFrame").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.FindGameObjectWithTag("SyctheFrame").GetComponent<Image>().color = new Color32(0, 225, 225, 255);
        }
        typeOfWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().typeOfWeapon;
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

        if (isOneHitKill)
        {
            weaponDamage = int.MaxValue;
        }
        else
        {
            if (typeOfWeapon == 0)
            {
                weaponDamage = damageOfHammer;
            }
            else if (typeOfWeapon == 1)
            {
                weaponDamage = damageOfSword;
            }
            else if (typeOfWeapon == 2)
            {
                weaponDamage = damageOfSycthe;
            }
        }
    }

    public void ToggleOneHitKill()
    {
        isOneHitKill = !isOneHitKill;
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

            if (!sound1.isPlaying)
            {
                sound1.Play();
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

            if (!sound2.isPlaying)
            {
                sound2.Play();
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

            if (!sound3.isPlaying)
            {
                sound3.Play();
            }
        }

        if (loot != null)
        {
            loot.GetComponent<Loot>().receiveDamage(weaponDamage);
        }

        if (enemy != null)
        {
            enemy.GetComponent<EnemyHp>().DecreaseEntityHp(weaponDamage);
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
        if (typeOfWeapon == 0)
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

        if (typeOfWeapon == 1 || typeOfWeapon == 2)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                enemy = other;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        loot = null;
    }
}
