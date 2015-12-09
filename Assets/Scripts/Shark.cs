using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour
{
    private Rigidbody2D rb;

    Animator animator;

    public float maxSpeedV = 5f;
    private bool facingRight = true;
    public int jumpTokens = 2;
    public enum states { Walking, Idle, Jumping, Diving }
    public states state;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        GameObject redplants = GameObject.Find("Back_Plants");
        float sx = Camera.main.transform.position.x / 8;
        Vector3 vec = new Vector3(sx, 0, 0);
        redplants.transform.position = vec;


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


        //Vector3 cameraFlipped = Camera.main.transform.localScale;
        //cameraFlipped.x = cameraFlipped.x * -1;
        //Camera.main.transform.localScale = cameraFlipped;
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


}
