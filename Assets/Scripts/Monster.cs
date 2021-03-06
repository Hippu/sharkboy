﻿using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
	public float EnemyHealth = 100;
	public GameObject EnemyBullet;
	public float EnemyBulletSpeed = 5f;
	public float EnemyDamage = 15f;
	public AudioClip EnemyExplosion;
	public GameObject Shell;
    private GameObject player;
    public bool patrols = false;
    public float patrolRadius;
    public float speed;
    private float minX;
    private float maxX;
    private bool movingRight = true;
    

	// Use this for initialization
	void Start () {
        if (EnemyBullet != null) {
            InvokeRepeating("EnemyFire", 0.0000001f, 1f);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        minX = transform.position.x - patrolRadius;
        maxX = transform.position.x + patrolRadius;
    }
	
	// Update is called once per frame
	void Update () {
        if (patrols) { PatrolUpdate(); };
		
	}

    void PatrolUpdate()
    {
        if (movingRight && transform.position.x < maxX)
        {
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }
        else if (!movingRight && transform.position.x > minX)
        {
            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y);
        }
        else
        {
            movingRight = !movingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }
    }

	void EnemyFire (){
        if (Vector3.Distance(player.transform.position, transform.position) < 15) {
            GameObject waterball = Instantiate(EnemyBullet, this.transform.position, Quaternion.identity) as GameObject;
            waterball.GetComponent<Rigidbody2D>().velocity = new Vector3(-EnemyBulletSpeed, Random.Range(-2f, 2f), 0f);
            this.GetComponent<AudioSource>().Play();
        }	
	}

	void OnTriggerEnter2D (Collider2D Trigger) {
		Projectile Projectile = Trigger.gameObject.GetComponent<Projectile>();
		if (Projectile) {
			Projectile.BulletDestroy();
			EnemyHealth -= Projectile.BulletDamage;
		}
		if (EnemyHealth<= 0f){
			Instantiate(Shell,this.transform.position,Quaternion.identity);
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(EnemyExplosion,this.transform.position,0.5f);

		}
	}
}
