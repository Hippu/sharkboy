using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject innerObject;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (rb.velocity.x > -0.01f && rb.velocity.x < 0.01f && rb.velocity.y > -0.01f && rb.velocity.y < 0.01f)
        {
            GameObject obj =Instantiate(innerObject, transform.position, Quaternion.identity) as GameObject;
            Destroy(this.gameObject);
        }
	}

    public void setInnerObject(GameObject obj)
    {
        innerObject = obj;
        GetComponent<SpriteRenderer>().sprite = obj.GetComponent<SpriteRenderer>().sprite;
        this.transform.localScale = obj.GetComponent<Transform>().localScale;
    }

}
