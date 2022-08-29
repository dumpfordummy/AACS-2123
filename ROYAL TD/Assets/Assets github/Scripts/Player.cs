using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameCharacter
{
    public float moveSpeed = 1;
    public Animator animator;
    private float horizontalInput = 0;
    private float verticalInput = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();       
    }

    public void move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        Debug.Log("Horizontal :" + horizontalInput);
        Debug.Log("Vertical :" + verticalInput);

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);

        if (horizontalInput > 0)
            transform.localScale = new Vector3(-1, 1, 0);
        else if (horizontalInput < 0)
            transform.localScale = new Vector3(1, 1, 0);

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Attack");
            animator.SetBool("Attack", true);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            animator.SetBool("Attack", false);
        }
    }
}
