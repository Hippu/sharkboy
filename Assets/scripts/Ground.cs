using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	public LevelManager LevelManager;
	void OnTriggerEnter2D (Collider2D trigger) {
		print ("Trigger");
		LevelManager.LoadLevel ("Win");
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision");
	}

}
