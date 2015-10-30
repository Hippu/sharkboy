using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
static Music instance = null;


	void Awake () {
		Debug.Log ("Music Awake "+ GetInstanceID());
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicated music player destroyed!");
		}else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	void Start () {
		Debug.Log ("Music Start "+ GetInstanceID());

	}
	
	void Update () {
	
	}
}
