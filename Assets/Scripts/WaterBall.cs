using UnityEngine;
using System.Collections;

public class WaterBall : MonoBehaviour {
	public float EnemyBulletDamage = 15f;
	public AudioClip EnemyBullets;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player"){
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(EnemyBullets,transform.position,1f);
		}
	}
}
