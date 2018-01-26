using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool jumpEnable = false;
    private Rigidbody2D rb;
    public float speed;
    public float jumpPower;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveHorizontal, 0) * speed;
        Saut();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        jumpEnable = collision.collider.gameObject.CompareTag("Ground");

   
    }
    void Saut()
    {
        if (Input.GetKeyDown("space") && jumpEnable == true)
        {
            rb.velocity = new Vector2(0, 1) * jumpPower; 
            jumpEnable = false;
        }
    }
}
