using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreen : MonoBehaviour {

	// Use this for initialization
	public int offScreenAmount = 40;
	public int collWidth = 20;
	void Start () {
		Debug.Log (gameObject.name);
		if(gameObject.name == "OffScreen"){
			gameObject.transform.position = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width+offScreenAmount,Screen.height/2,1));
			gameObject.GetComponent<BoxCollider2D> ().size = new Vector2 (collWidth,Screen.height);
			gameObject.name = "RightOffscreen";
			gameObject.tag = "bounds";
			GameObject left = new GameObject ();;
			left.gameObject.name = "LeftOffscreen";
			left.gameObject.tag = "bounds";
			left = Instantiate (gameObject,Camera.main.ScreenToWorldPoint (new Vector3(-offScreenAmount,Screen.height/2,1)),Quaternion.identity) as GameObject;
			left.gameObject.GetComponent<BoxCollider2D> ().size = new Vector2 (collWidth,Screen.height);
			left.gameObject.name = "LeftOffscreen";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
