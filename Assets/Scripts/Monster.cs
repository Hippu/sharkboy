using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
	public float EnemyHealth = 100;
	public GameObject EnemyBullet;
	public float EnemyBulletSpeed = 5f;
	public float EnemyDamage = 15f;
	public AudioClip EnemyExplosion;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("EnemyFire", 0.0000001f,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void EnemyFire (){
		GameObject waterball = Instantiate(EnemyBullet,this.transform.position,Quaternion.identity) as GameObject;
		waterball.GetComponent<Rigidbody2D>().velocity = new Vector3 (-EnemyBulletSpeed,Random.Range(-2f,2f),0f);
		this.GetComponent<AudioSource>().Play();
	}

	void OnTriggerEnter2D (Collider2D Trigger) {
		Projectile Projectile = Trigger.gameObject.GetComponent<Projectile>();
		if (Projectile) {
			Projectile.BulletDestroy();
			EnemyHealth -= Projectile.BulletDamage;
		}
		if (EnemyHealth<= 0f){
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(EnemyExplosion,this.transform.position,0.5f);
			
		}
	}
}
