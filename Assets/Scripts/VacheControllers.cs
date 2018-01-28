using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacheControllers : IA_Ennemy {

    public int pdv;

    new void  OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("GaletteSaucisse"))
        {
            pdv--;
            if(pdv == 0)
            {
                DestroyObject(gameObject);
            }
        }
    }
}
