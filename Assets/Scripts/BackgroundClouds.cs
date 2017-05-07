using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundClouds : MonoBehaviour {
	public Sprite[] cloudSprites = new Sprite[3];
	public int maxClouds = 4;
	public int speed = 1;
	private float nextSpawnTime;
	private GameObject[] clouds;

	public Vector2 calcSpawnPosition(GameObject sprite)
	{
		float spawnY = Random.Range(0, Screen.height);
		float spawnX = Camera.main.WorldToScreenPoint(new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).x - sprite.GetComponent<SpriteRenderer>().sprite.bounds.max.x,0,0)).x;
		return Camera.main.ScreenToWorldPoint (new Vector3(spawnX, spawnY, 1));
	}
	// Use this for initialization
	void Start () {
		clouds = new GameObject[maxClouds];
		for(int i = 0; i < clouds.Length ; i++)
		{
			clouds [i] = new GameObject ();
			clouds[i].AddComponent<SpriteRenderer> ();
			clouds[i].GetComponent<SpriteRenderer>().sprite = cloudSprites[Random.Range(0,cloudSprites.Length)];
			clouds [i].transform.position = Camera.main.ScreenToWorldPoint (new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 1));
		}

	}
	
	// Update is called once per frame
	void Update () {
		for( int i = 0; i < clouds.Length; i++)
		{
			if(Camera.main.WorldToScreenPoint(new Vector3(clouds[i].transform.position.x - clouds[i].GetComponent<SpriteRenderer>().sprite.bounds.max.x,0,0)).x > Screen.width){
				clouds [i].transform.position = calcSpawnPosition (clouds[i]);
			}
			clouds[i].transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
	}
}
