using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Ennemy : MonoBehaviour {
	public GameObject cible;
    public float timeBetweenLoop = 5;
    private int vitesse;
	private float x_cible;
	private int visionMin;
	private int visionMax;
	protected Rigidbody2D rb;
    public float speed;
	// Use this for initialization
     void Start () {
		rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SoundLoop());
	}

    IEnumerator SoundLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenLoop);
            GetComponent<AudioSource>().Play();
        }
    }
	
	// Update is called once per frame
	protected void FixedUpdate () {
		x_cible = cible.transform.position.x - this.transform.position.x;
		x_cible = x_cible / Mathf.Abs (x_cible);
		rb.velocity = new Vector2 (x_cible * speed, rb.velocity.y);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("GaletteSaucisse"))
        {
            speed = 12;
        }
    }
}
