using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	public GameObject bullet;

	float xSpeed = 10;
	int bulletTimer = 0;

	// Update is called once per frame
	void FixedUpdate () {
		

		if (Input.GetKey (KeyCode.Space) == true) {
			if (bulletTimer == 0) {
				Instantiate (bullet,new Vector3(transform.position.x,transform.position.y+1f,transform.position.z), Quaternion.identity);
				bulletTimer = 10;
			}
		}


		if (bulletTimer > 0) {
			bulletTimer--;
		}

		transform.Translate (xSpeed *Input.GetAxis("Horizontal")* Time.deltaTime, 0, 0);

	


	}
}
