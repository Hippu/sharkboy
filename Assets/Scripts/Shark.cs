using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour
{
    private Rigidbody2D rb;

    Animator animator;

    public float maxSpeedV = 5f;
    private bool facingRight = true;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown("up")) && (animator.GetBool("grounded")))
        {
            rb.velocity = new Vector2(rb.velocity.x, maxSpeedV);
            animator.SetBool("grounded", false);
        }
        if (Input.GetKey("right"))
        {
            if (!facingRight)
            {
                Flip();
            }
            rb.velocity = new Vector2(maxSpeedV, rb.velocity.y);

        }
        if (Input.GetKey("left"))
        {
            if (facingRight) { Flip(); }
            rb.velocity = new Vector2(-maxSpeedV, rb.velocity.y);

        }

        if ((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Input.GetKeyDown("up"))
        {

            rb.velocity = new Vector2(rb.velocity.x, maxSpeedV * 2);
            animator.SetBool("grounded", false);
        }


        if ((rb.velocity.x <= 0.1) && (rb.velocity.x >= -0.1)) { animator.SetBool("walking", false); } else { animator.SetBool("walking", true); }


        GameObject redplants = GameObject.Find("Back_Plants");
        float sx = rb.transform.position.x / 6;
        Vector3 vec = new Vector3(sx, 0, 0);
        redplants.transform.position = vec;


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
            animator.SetBool("grounded", true);
        }
    }


}
