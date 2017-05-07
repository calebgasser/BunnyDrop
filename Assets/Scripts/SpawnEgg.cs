using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEgg : MonoBehaviour {

	public Transform bunny;
	// Use this for initialization
	void Start () {
		gameObject.transform.position = Camera.main.ScreenToWorldPoint (new Vector3(0,Screen.height,1));
	}

	void CastRay(){
		RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if(hit.collider != null){
			if(hit.collider.name == gameObject.name)
			Instantiate (bunny,new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,1),Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			CastRay ();
		}
	}
}
