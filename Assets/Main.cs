using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization

	public List<GameObject> enemies = new List<GameObject>();

	//MAX ENEMIES 15!!
	//normal
	int[] xposA = { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
	int[] yposA = { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2 };
	//defense
	int[] xposB = { 1, 2, 3, 4, 5};
	float[] yposB = { 0.5f, 0.25f , 0, 0.25f, 0.5f};

	//last
	int[] xposC = { 2, 3, 4};
	float[] yposC = { 0.5f, 0, 0.5f};
	//final
	int[] xposD = { 3, 3};
	float[] yposD = { 1f, 0};

	public int total = 15;

	float gap = 4f;

	void Start () {

		for (int i = 0; i < enemies.Count; i++) {
			enemies [i].GetComponent<EnemyAI> ().destination = new Vector3 ((2.0f * xposA [i]) - gap, (2.0f * yposA [i]), 0);
			enemies [i].GetComponent<EnemyAI> ().id = i;
		}
	}


	void KillEnemy(int id){
		Destroy (enemies [id]);
		enemies.Remove (enemies [id]);
		ResetID (); 
	}


	void ResetID(){
		for (int i = 0; i < enemies.Count; i++) {
			enemies [i].GetComponent<EnemyAI> ().id = i;
		}
	}
	void ChangeFormation(){
		if (enemies.Count < 3) {
			for (int i = 0; i < enemies.Count; i++) {
				enemies [i].GetComponent<EnemyAI> ().destination = new Vector3 ((2.0f * xposD [i]) - gap, (2.0f * yposD [i]), 0);
				enemies [i].GetComponent<EnemyAI> ().id = i;
			}
		} else if (enemies.Count < 4) {
			for (int i = 0; i < enemies.Count; i++) {
				enemies [i].GetComponent<EnemyAI> ().destination = new Vector3 ((2.0f * xposC [i]) - gap, (2.0f * yposC [i]), 0);
				enemies [i].GetComponent<EnemyAI> ().id = i;
			}
		} else if (enemies.Count < 6) {
			for (int i = 0; i < enemies.Count; i++) {
				enemies [i].GetComponent<EnemyAI> ().destination = new Vector3 ((2.0f * xposB [i]) - gap, (2.0f * yposB [i]), 0);
				enemies [i].GetComponent<EnemyAI> ().id = i;
			}
		} else {
			for (int i = 0; i < enemies.Count; i++) {
				enemies [i].GetComponent<EnemyAI> ().destination = new Vector3 ((2.0f * xposA [i]) - gap, (2.0f * yposA [i]), 0);
				enemies [i].GetComponent<EnemyAI> ().id = i;
			}
		}
	}
		
	int reformTimer= 0;

	void Update () {
		
		if (reformTimer > 0) {
			reformTimer--;
		}

		if (reformTimer == 0) {
			ChangeFormation ();
			reformTimer = 200;
		}


	}
}
