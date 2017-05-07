using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBird : MonoBehaviour {

	private bool isFlyingRight = true;
	public Vector2 flySpeed = new Vector2(100.0f,300.0f);
	private float speed;


	// Use this for initialization
	void Start () {
		speed = Random.Range (flySpeed.x, flySpeed.y);
		if(gameObject.transform.position.x > 0){
			isFlyingRight = false;
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
		}
	}


	// Update is called once per frame
	void Update () {
		if (isFlyingRight) {
			gameObject.transform.Translate (-Vector2.left * speed * Time.deltaTime);
		} else {
			gameObject.transform.Translate (Vector2.left * speed * Time.deltaTime);	
		}
	}
}
