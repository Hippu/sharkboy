using UnityEngine;
using System.Collections;

public class Hamberger : MonoBehaviour {
	public AudioClip HambergerAudio;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D (Collider2D Tri) {
		if (Tri.gameObject.tag == "Player"){
			Tri.GetComponent<SizeChanger>().Increment();
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(HambergerAudio,this.transform.position,2f);
			
			
		}
	}
}
