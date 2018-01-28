using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraControllers : MonoBehaviour {
    public float y;
    public float offsetX = 1;
    public float offsetY = 1;
    public GameObject player;
	// Use this for initialization
	void Start () {

       y = player.transform.position.y + offsetY;

    }
	
	// Update is called once per frame
	void LateUpdate () {
        float x = player.transform.position.x + offsetX;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);

	}
}
