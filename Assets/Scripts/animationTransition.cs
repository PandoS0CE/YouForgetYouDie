using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationTransition : MonoBehaviour {

    private bool etat = true;
    public float timeBetweenLoop = 5;
    private void Start()
    {
        gameObject.SetActive(etat);
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeBetweenLoop);
            gameObject.GetComponent<SpriteRenderer>().enabled = etat;
            etat = !etat;
            
        }
        

    }

}
