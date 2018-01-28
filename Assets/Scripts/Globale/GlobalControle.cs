using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControle : MonoBehaviour {

    // Use this for initialization
    static GlobalControle Instance;

    // boolean oublie
    public bool forgetJump;
    public bool forgetSquat;
    public bool forgetGoLeft;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
