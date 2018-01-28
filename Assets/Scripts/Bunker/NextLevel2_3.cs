using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel2_3 : MonoBehaviour {

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("level3", LoadSceneMode.Single);
    }
}
