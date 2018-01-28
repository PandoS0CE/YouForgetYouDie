using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animationTransition : MonoBehaviour {

    private bool etat = true;
    public float timeBetweenLoop = 5;
    public float timeAnimation;
    public GlobalControle globalControle;

    private void Start()
    {
        gameObject.SetActive(etat);
        StartCoroutine(BlinkText());
        StartCoroutine(ChangeScene());

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

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(timeAnimation);
        string scene = "level" + GlobalControle.Instance.currentLevel;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

}
