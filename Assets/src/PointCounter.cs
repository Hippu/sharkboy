using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour {

    private int points = 0;
    private Text uiString;

    public void addPoint()
    {
        this.points += 1;
        Debug.Log("Point added");
        uiString.text = "Points: " + this.points;
    }

    public int getPoints()
    {
        return this.points;
    }
	// Use this for initialization
	void Start () {
        uiString = GameObject.Find("PointsText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
