using UnityEngine;
using System.Collections;

public class Boxes_1 : MonoBehaviour {
public Sprite[] Sprites;
public GameObject Ins;
private bool Unbox = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			if (Unbox == false){
			Unbox = true;
			this.GetComponent<SpriteRenderer>().sprite = Sprites[0];
			this.GetComponent<AudioSource>().Play();
			Instantiate(Ins,this.transform.position,Quaternion.identity);
			}
		}
	}
}
