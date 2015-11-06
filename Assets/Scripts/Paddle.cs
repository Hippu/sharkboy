using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width *16 ;
		print (mousePosInBlocks);
		Vector3 PaddlePos = new Vector3 (Mathf.Clamp(mousePosInBlocks,0.5f,15.5f), 0.5f, 0f);
		this.transform.position = PaddlePos;
	}
}
