using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour {
	
    private Rigidbody2D rb;
    Animator animator;
    public float maxSpeedV = 5f;
    private bool facingRight = true;
    public int jumpTokens = 2;
    public enum states { Walking, Idle, Jumping, Diving }
    public states state;
    public Rigidbody2D projectile;
    public float shootCooldown = 0.25f;
    public Transform shootFrom;
    private float lastShot;
    private Stack eaten;
    private PointCounter counter;
	public float SharkHealth = 50;
	public AudioClip EnemyCollision;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastShot = Time.time;
        eaten = new Stack();
        counter = GameObject.Find("PointCounter").GetComponent<PointCounter>();
    }


    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Horizontal") > 0.1f || Input.GetAxis("Horizontal") < -0.1f) && state != states.Diving)
        {
            if ((facingRight && Input.GetAxis("Horizontal") < 0) ||
                (!facingRight && Input.GetAxis("Horizontal") > 0))
            { Flip(); }

            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeedV, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && jumpTokens > 0)
        {
            changeState(states.Jumping);
        }

        if (Input.GetButtonDown("Dive") && state == states.Jumping)
        {
            changeState(states.Diving);
        }


        if ((rb.velocity.x <= 0.1) && (rb.velocity.x >= -0.1) && state != states.Jumping && state != states.Diving)
        { changeState(states.Idle); }
        else if (state != states.Jumping && state != states.Diving)
        {
            changeState(states.Walking);
        }

        if (state == states.Walking && rb.velocity.x < 2 && rb.velocity.x > -2)
        {
            animator.speed = Mathf.Abs(rb.velocity.x) / 2;
        }
        else
        {
            animator.speed = 1;
        }

        if (Input.GetAxis("Fire") > 0)
        {
            Fire();
        }

        GameObject redplants = GameObject.Find("Back_Plants");
        if (redplants != null) {
            float sx = Camera.main.transform.position.x / 8;
            Vector3 vec = new Vector3(sx, 0, 0);
            redplants.transform.position = vec;
        }
        
    }

    private void changeState(states newState)
    {
        state = newState;

        switch (newState)
        {
            case states.Jumping:
                jumpTokens += -1;
                rb.velocity = new Vector2(rb.velocity.x, maxSpeedV * 2);
                animator.SetBool("grounded", false);
                break;
            case states.Idle:
                rb.rotation = 0.0f;
                animator.SetBool("walking", false);
                animator.SetBool("grounded", true);
                jumpTokens = 2;
                break;
            case states.Walking:
                rb.rotation = 0.0f;
                animator.SetBool("walking", true);
                break;
            case states.Diving:
                jumpTokens = 0;
                animator.SetBool("grounded", false);
                if (facingRight)
                {
                    rb.velocity = new Vector2(maxSpeedV * 2, rb.velocity.y);
                    rb.rotation = -90.0f;
                }
                else
                {
                    rb.velocity = new Vector2(-maxSpeedV * 2, rb.velocity.y);
                    rb.rotation = 90.0f;
                }
                break;
            default:
                break;

        }
    }

    /// <summary>
    /// Flips the sprite by multiplying its scale with -1
    /// </summary>
    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 flipped = transform.localScale;
        flipped.x = flipped.x * -1;
        transform.localScale = flipped;
    }

    public void Fire()
    {
        if (Time.time > lastShot + shootCooldown && eaten.Count > 0)
        {
            lastShot = Time.time;
            GameObject projectileInner = (GameObject) eaten.Pop();
            this.projectile.gameObject.GetComponent<Projectile>().setInnerObject(projectileInner);
            Rigidbody2D p = Instantiate(projectile, shootFrom.position, Quaternion.identity) as Rigidbody2D;
            counter.removePoint();
            if (facingRight) {
                p.velocity = rb.velocity + new Vector2(20f, 0f);
            } else
            {
                p.velocity = rb.velocity + new Vector2(-20f, 0f);
            }
                            
        }
    }

    public void addEaten(GameObject obj)
    {
        eaten.Push(obj);
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "seahorse")
        {
            //Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "squid")
        {
            //Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "sand")
        {
            changeState(states.Idle);
        }
    }



	void OnTriggerEnter2D (Collider2D tri){
		WaterBall WaterBall = tri.gameObject.GetComponent<WaterBall>();
		if (WaterBall){
			SharkHealth -= WaterBall.EnemyBulletDamage;
		}
		Monster Monster = tri.gameObject.GetComponent<Monster>();
		if (Monster){
			SharkHealth -= Monster.EnemyDamage;
			AudioSource.PlayClipAtPoint(EnemyCollision,this.transform.position,1f);
		}
		if (SharkHealth <= 0f){
			Application.LoadLevel("Lose");
		}
	}

}
