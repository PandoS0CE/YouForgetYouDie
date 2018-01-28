using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControle : MonoBehaviour {

    // Use this for initialization
    public static GlobalControle Instance;

    // boolean oublie
    public bool forgetJump = false;
    public bool forgetSquat = false;
    public bool forgetGoLeft = false;
    public int currentLevel;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            currentLevel = 1;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
