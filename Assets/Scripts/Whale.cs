using UnityEngine;
using System.Collections;

public class Whale : MonoBehaviour {

    public GameObject sign;
    public int foodRequired;
    public string nextLevel;
    private int foodEaten = 0;

	// Use this for initialization
	void Start () {
        Debug.Log("Behaviour started");
        setSignText();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            this.foodEaten += 1;
            setSignText();
            Destroy(other.gameObject);
            Debug.Log("Whale ate something");
            if (foodEaten >= foodRequired)
            {
                Application.LoadLevel(nextLevel);
            }
        }
    }

    void setSignText()
    {
        sign.GetComponentInChildren<TextMesh>().text = (foodRequired - foodEaten).ToString();
    }
}
