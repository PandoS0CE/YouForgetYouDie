﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======

>>>>>>> c6528712934ffe5539f0706ad606f602c56f9ab9

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    //ui
    #region
    public Text loseText;
    public Button buttonRestart;
    #endregion
    // Variable saut
    #region 
    private bool isJumping = false;
    private bool canJump = true;
    public float jumpPower = 5;
    private Vector2 posInitSaut;
    public float jumpHeigth = 2;
    #endregion Saut

    // Animations
    Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.enabled = true;
<<<<<<< HEAD
        buttonRestart.onClick.AddListener(Restart);
        buttonRestart.gameObject.SetActive(false);
=======
>>>>>>> c6528712934ffe5539f0706ad606f602c56f9ab9
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.x >= 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        Deplacer();
        
        Accroupir();

        Saut();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }

        if (collision.collider.gameObject.CompareTag("Death"))
        {
            Death();
        }
    }

    void Saut()
    {
        //print("CanJump:" + canJump);
        //print("isJumping:" + isJumping);
        if(!canJump)
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown("space") && !isJumping && canJump)
        {
            isJumping = true;
            canJump = false;
            posInitSaut = transform.position;
        }
        if (transform.position.y - posInitSaut.y < jumpHeigth && isJumping)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        else
        {
            isJumping = false;
        }

    }

    void Accroupir()
    {
        if (Input.GetKey("down"))
        {
            anim.SetBool("isAccroupi", true);
        }
        else
        {
            anim.SetBool("isAccroupi", false);
        }
    }

    void Deplacer()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal, 0) * speed;
        bool running = rb.velocity.x != 0;
        anim.SetBool("isRunning", running);    
    }

    void Death()
    {
        gameObject.SetActive(false);
        loseText.text = "You're dead";
        buttonRestart.gameObject.SetActive(true);
    }

<<<<<<< HEAD
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
=======
    
>>>>>>> c6528712934ffe5539f0706ad606f602c56f9ab9
}
