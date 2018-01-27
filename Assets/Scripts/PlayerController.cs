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
    #endregion

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveHorizontal, 0) * speed;
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
}
