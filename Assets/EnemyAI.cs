using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {


	GameObject Main;
	public Vector3 destination;
	// Use this for initialization


	public int id;
	void Start () {
		//find Main
		Main = GameObject.Find ("Main");

		//add enemy to the array
		Main.GetComponent<Main>().enemies.Add (gameObject);

		//set position to destination
		destination = transform.position;
	}
		
	// Update is called once per frame
	void Update () {

		//move to destincation
		transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime*5f);

		//move back and forth
		transform.position = new Vector3(transform.position.x- Mathf.PingPong(Time.time*.2f, 0.3f), transform.position.y, transform.position.z);
	}


	void OnTriggerEnter2D(Collider2D other){
		Main.SendMessage ("KillEnemy", id);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}

}
