using UnityEngine;
using System.Collections;

public class shark : MonoBehaviour {
    private Rigidbody2D rb;

    Animator animator;

    public float maxSpeedV = 5f;
    

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        

    }
	
	// Update is called once per frame
	void Update() {


        if ((Input.GetKeyDown("up")) && (animator.GetBool("grounded"))) {
            rb.velocity = new Vector2(rb.velocity.x, maxSpeedV);
            animator.SetBool("grounded", false);
        }
        if (Input.GetKey("right")) 
        {
            animator.SetBool("dirrev", false);
            //animator.SetBool("walking", true);
            //new WaitForSeconds(1);
            rb.velocity = new Vector2(maxSpeedV, rb.velocity.y);
            //animator.SetBool("grounded", false);
            //Debug.Log("right");
        }
        if (Input.GetKey("left"))
        {

            animator.SetBool("dirrev", true);
            //new WaitForSeconds(1);
            rb.velocity = new Vector2(-maxSpeedV, rb.velocity.y);
            //animator.SetBool("grounded", false);
            //Debug.Log("right");
        }

        if ((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Input.GetKeyDown("up"))
        {

            rb.velocity = new Vector2(rb.velocity.x, maxSpeedV*2);
            animator.SetBool("grounded", false);
        }


        if ((rb.velocity.x <= 0.1) && (rb.velocity.x >= -0.1)) { animator.SetBool("walking", false); } else { animator.SetBool("walking", true); }
        //Debug.Log(rb.velocity.x);
        //Debug.Log(animator.GetBool("walking"));

        GameObject redplants = GameObject.Find("Back_Plants");
        float sx = rb.transform.position.x / 6;
        Vector3 vec = new Vector3(sx, 0, 0);
        redplants.transform.position = vec;



        /*
        float jh = rb.transform.position.y;
        GameObject redplants = GameObject.Find("Back_Plants");
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (h>0)
        {
            animator.SetBool("dirrev", false);
        } else if (h<0)
        {
            animator.SetBool("dirrev", true);
        }

        if (v>=0) rb.AddForce(Vector2.up * 20* Mathf.Abs(v));  


        if (jh < -3.37) { animator.SetBool("grounded", true); animator.SetBool("walking", false);  } else { animator.SetBool("grounded", false); }
        if ((h<=0.1) && (h>=-0.1))
        {
            animator.SetBool("walking", false);
        } else
        {
            rb.AddForce(Vector2.right * 8 * h);
            animator.SetBool("walking", true);
            
        }
        float sx = rb.transform.position.x / 6;
        Vector3 vec=new Vector3(sx,0,0);
        redplants.transform.position=vec;


        */


    }





    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "seahorse")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "squid")
        {
            Destroy(col.gameObject);
        }       
        if (col.gameObject.tag == "sand")
        {
            animator.SetBool("grounded", true);
        }
    }


}
