using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    // Variable saut
    # region 
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
            gameObject.SetActive(false);
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
}
