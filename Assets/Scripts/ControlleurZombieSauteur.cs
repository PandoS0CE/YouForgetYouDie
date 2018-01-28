using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlleurZombieSauteur : IA_Ennemy
{

    private bool isJumping = false;
    private bool canJump = true;
    private Vector2 posInitSaut;
    public float jumpHeigth;
    public float jumpPower;
    public float distanceDetectionSaut;

    // Update is called once per frame
    void FixedUpdate()
    {
        base.FixedUpdate();
        if (Mathf.Abs(transform.position.x - cible.transform.position.x) < distanceDetectionSaut)
        {
            Saut();
        }

    }

    void Saut()
    {
        if (!isJumping && canJump)
        {
            isJumping = true;
            canJump = false;
            posInitSaut = transform.position;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
