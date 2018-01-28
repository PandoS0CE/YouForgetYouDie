﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    // ui
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

    // Boolean compétence
    #region
    public bool forgetJump;
    public bool forgetSquat;
    public bool forgetGoLeft;

    private bool hasJump = false;
    private bool hasSquat = false;
    private bool hasGoLeft = false;

    public GlobalControle globalControle;
    #endregion

    // Boolean mur
    #region
    #endregion
    // Animations
    Animator anim;

    // Use this for initialization
    void Start()
    {
        // DontDestroyOnLoad(GetComponent  <ScriptableObject>());
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.enabled = true;
        buttonRestart.onClick.AddListener(Restart);
        buttonRestart.gameObject.SetActive(false);
        LoadForget();
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

        else if (collision.collider.gameObject.CompareTag("PassageLvSuivant"))
        {
            print("Save");
            SaveForget();
            GlobalControle.Instance.currentLevel++;
            string lvSuivant = "Animation";
            SceneManager.LoadScene(lvSuivant, LoadSceneMode.Single);

        }
    }

    void Saut()
    {
        if(!canJump)
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown("space") && !isJumping && canJump && !forgetJump)
        {
            isJumping = true;
            canJump = false;
            posInitSaut = transform.position;
            hasJump = true;
        }
        if (transform.position.y - posInitSaut.y < jumpHeigth && isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, 1 * jumpPower);
        }
        else
        {
            isJumping = false;
        }

    }

    void Accroupir()
    {
        if (Input.GetKey("down") && !forgetSquat )
        {
            anim.SetBool("isAccroupi", true);
            hasSquat = true;
        }
        else
        {
            anim.SetBool("isAccroupi", false);
        }
    }

    void Deplacer()
    {
        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }
        if (Input.GetKey("left") && !forgetGoLeft)
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
            hasGoLeft = true;
        }
        bool running = rb.velocity.x != 0;
        anim.SetBool("isRunning", running);    
    }

    void Death()
    {
        gameObject.SetActive(false);
        loseText.text = "You're dead";
        buttonRestart.gameObject.SetActive(true);
    }

    private void Restart()
    {
        SceneManager.LoadScene("level1", LoadSceneMode.Single);
    }

    private void LoadForget()
    {
        forgetGoLeft = GlobalControle.Instance.forgetGoLeft;
        forgetJump = GlobalControle.Instance.forgetJump;
        forgetSquat = GlobalControle.Instance.forgetSquat;
        hasGoLeft = false;
        hasJump = false;
        hasSquat = false;
    }

    private void SaveForget()
    {
        GlobalControle.Instance.forgetSquat = !hasSquat;
        GlobalControle.Instance.forgetJump = !hasJump;
        GlobalControle.Instance.forgetGoLeft = !hasGoLeft;
    }
}
