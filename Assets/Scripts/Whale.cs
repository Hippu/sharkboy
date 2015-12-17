using UnityEngine;
using System.Collections;

public class Whale : MonoBehaviour {

    public GameObject sign;
    public int foodRequired;
    public string nextLevel;
    private int foodEaten = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "player")
        {
            this.foodEaten += 1;
            Destroy(other.gameObject);
            if (foodEaten >= foodRequired)
            {
                Application.LoadLevel(nextLevel);
            }
        }
    }
}
