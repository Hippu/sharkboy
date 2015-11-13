using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

    PointCounter counter;

	// Use this for initialization
	void Start () {
        this.counter = GameObject.Find("PointCounter").GetComponent<PointCounter>();
        Debug.Log(counter);
        Debug.Log("Point created with counter", this.counter);
	}

	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with " + other.tag);
        if (other.tag == "Player") {
            counter.addPoint();
            this.GetComponent<AudioSource>().Play();
            this.Disable();
            //Destroy(this.gameObject);
        }
    }

    void Disable()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
    }
}
