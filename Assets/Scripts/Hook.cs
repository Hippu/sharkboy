using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {
	private bool Untouched = true;
	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D trigger) {
		if (Untouched){
			if (trigger.tag == "Player"){
				Untouched = false;
				trigger.GetComponent<SizeChanger>().Decrement();
				this.GetComponent<AudioSource>().Play();
			}
		}
	}
}
