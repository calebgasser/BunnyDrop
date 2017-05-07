using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour {

	private bool isHeld;
	public float fallSpeed = 1.0f;
	public float acceleration = 2.0f;
	public float maxSpeed = 50.0f;
	public float runSpeed = 100.0f;
	public bool isFalling;
	private float holdRange;
	public Animator anim;
	public GameObject gameManager;
	public AudioClip death;
	void Awake(){
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
	}
	// Use this for initialization
	void Start () {
		isHeld = true;
		isFalling = true;
		anim = gameObject.GetComponent<Animator> ();
		holdRange = 32;
	}

	void CastRayDown(){
		RaycastHit2D hitDown = Physics2D.Raycast (transform.position,-transform.up,0.1f);
		RaycastHit2D hitLeft = Physics2D.Raycast (new Vector2(transform.position.x, transform.position.y + GetComponent<SpriteRenderer>().sprite.bounds.size.y),-transform.right,0.1f);
		if(hitDown.collider != null){
			if (hitDown.collider.name == "Floor") {
				isFalling = false;
			} else {
				isFalling = true;
			}
			if(hitLeft.collider.tag == "bounds"){
				gameManager.GetComponent<GameManager> ().Score += 1;
				Destroy (gameObject);
			}
		}
		if (isFalling) {
			if (fallSpeed <= maxSpeed) {
				fallSpeed = acceleration * fallSpeed;
			}
			anim.SetInteger("Run", 0);
			gameObject.transform.Translate (Vector2.down * fallSpeed * Time.deltaTime);
		} else {
			anim.SetInteger ("Run", 1);
			if(gameObject.transform.position.x > 0){
				gameObject.transform.Translate (-Vector2.left * runSpeed * Time.deltaTime);
			} else{
				gameObject.transform.Translate (Vector2.left * runSpeed * Time.deltaTime);
			}
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "enemy"){
			gameManager.GetComponent<AudioSource> ().PlayOneShot(gameManager.GetComponent<GameManager>().bunnydeath,0.5f);
			gameManager.GetComponent<GameManager> ().Lives -= 1;
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		if(isHeld){
			if(Input.GetMouseButton(0)){
				if (Input.mousePosition.x > Screen.width - holdRange) {
					gameObject.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width - holdRange, 0, 0)).x,
						Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height - holdRange, 0)).y,
						1);
				} else if (Input.mousePosition.x < holdRange) {
					gameObject.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (new Vector3 (holdRange, 0, 0)).x,
						Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height - holdRange, 0)).y,
						1);
				} else {
					gameObject.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, 0, 0)).x,
						Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height - holdRange, 0)).y,
						1);
				}
			}
		}
		if(gameObject.transform.position.x > 0){
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
		} else{
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;
		}
		if(Input.GetMouseButtonUp(0)){
			isHeld = false;
		}
		if (!isHeld) {
			CastRayDown ();
		}

			
	}
}
