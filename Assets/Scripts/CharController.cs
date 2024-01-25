using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float jumpForce = 7f;
    private Rigidbody2D rb2d;
    private bool GameStarted;
    private Animator animator;
    private bool jumping;


    private bool Grounded;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>(); //caching
        animator = GetComponent<Animator>(); //caching
        Grounded = true;
    }

    private void Update()
    {
      if (Input.GetKeyDown("space"))
            {
                if (GameStarted && Grounded)
            {
                animator.SetTrigger("Jump");
                Grounded = false;
                jumping = true;
                
            }
                else
            {
                animator.SetBool("GameStarted", true);
                GameStarted = true;
            }
            }

      animator.SetBool("Grounded", Grounded);
    }

    private void FixedUpdate()
    {
        if (GameStarted)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

        }

        if (jumping)
        {
            rb2d.velocity = new Vector2(0f, jumpForce);
            jumping = false;
        }

            
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground")){
            Grounded = true;
        }
    }
}
