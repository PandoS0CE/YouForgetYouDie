using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraControllers : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);

	}
}
