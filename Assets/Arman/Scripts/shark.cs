using UnityEngine;
using System.Collections;

public class shark : MonoBehaviour {
    private Rigidbody2D rb;

    Animator animator;

	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        

    }
	
	// Update is called once per frame
	void Update () {
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


        
        
        
    }





    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "seahorse")
        {
            Destroy(col.gameObject);
        }
    }


}
