using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = new Color (0, 1,0,1);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (0, 10 * Time.deltaTime, 0);


		//remove bullet, when it's out of the screen
		if (transform.position.y > 5) {
			Destroy (gameObject);
		}
	}



}
