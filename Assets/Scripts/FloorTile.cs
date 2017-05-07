using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour {

	public Sprite spri;
	float numOfSprites;
	private GameObject[] floorTiles;
	private Vector2 colliderSize;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = Camera.main.ScreenToWorldPoint (new Vector3(0,0,1));
		numOfSprites = (Screen.width / spri.bounds.size.x)+1;
		floorTiles = new GameObject[(int)numOfSprites];
		colliderSize = new Vector2 ((numOfSprites * spri.bounds.size.x) * 2, spri.bounds.size.y);
		gameObject.GetComponent<BoxCollider2D> ().size = colliderSize;
		gameObject.GetComponent<BoxCollider2D> ().offset = new Vector2 ((colliderSize.x/4),(colliderSize.y/2));
		for(int i = 0; i < floorTiles.Length; i++){
			floorTiles [i] = new GameObject ();
			floorTiles [i].gameObject.transform.parent = gameObject.transform;
			floorTiles [i].AddComponent<SpriteRenderer> ();
			floorTiles [i].GetComponent<SpriteRenderer> ().sprite = spri;
			floorTiles [i].gameObject.transform.localPosition = new Vector3 (i * spri.bounds.size.x + (spri.bounds.size.x/2), spri.bounds.size.y/2,0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
