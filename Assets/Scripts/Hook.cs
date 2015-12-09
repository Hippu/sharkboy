using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D trigger) {
		if (trigger.tag == "Player"){
			Application.LoadLevel("Lose");
		}
	}
}
