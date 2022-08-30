using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameCharacter
{
    public float moveSpeed = 1;
    public Animator animator;
    private float horizontalInput = 0;
    private float verticalInput = 0;

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

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);

        if (horizontalInput > 0)
            transform.localScale = new Vector3(-1, 1, 0);
        else if (horizontalInput < 0)
            transform.localScale = new Vector3(1, 1, 0);

        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetBool("Attack", true);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            animator.SetBool("Attack", false);
        }
    }
}
