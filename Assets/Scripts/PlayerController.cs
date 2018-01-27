using System.Collections;
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
    #endregion




    // Animations
    Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.enabled = true;
        buttonRestart.onClick.AddListener(Restart);
        buttonRestart.gameObject.SetActive(false);
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
        if (Input.GetKeyDown("space") && !isJumping && canJump && !forgetJump)
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
        if (Input.GetKey("down") && !forgetSquat )
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
        //print(moveHorizontal);
        if(rb.velocity.x < 0 & forgetGoLeft)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveHorizontal, 0) * speed;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
