using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour {

	// Use this for initialization
	void Awake(){
		Camera.main.orthographicSize = Screen.height / 2;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
