using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpin : MonoBehaviour {

	// Use this for initialization
    public float speed = 150f;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
        transform.Rotate(Vector3.right, speed * Time.deltaTime);
	}
}
