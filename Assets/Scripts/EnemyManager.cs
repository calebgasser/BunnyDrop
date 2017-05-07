using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	public GameObject birdEnemy;
	public int amountOfEnemies = 1;
	public float spawnIncreaseTime = 10;
	public Sprite floor;
	private List<GameObject> enemyList;
	private int inScreenModifer;
	private int outOfScreenModifier;
	private float timeSinceLastIncrease = 0;

	bool randomBool(){
		return (Random.value > 0.5f);
	}

	public Vector2 calcSpawnPosition(Sprite sprite)
	{
		float spawnX;
		if (randomBool ()) {
			spawnX = -Screen.width - inScreenModifer; 
		} else {
			spawnX = Screen.width + inScreenModifer;
		}
		float spawnY = Random.Range(0 + (floor.bounds.size.y*2), Screen.height - floor.bounds.size.y);
		return Camera.main.ScreenToWorldPoint (new Vector3(spawnX, spawnY, 1));
	}

	bool outOfScreen(GameObject obj){
		Vector3 truePos = Camera.main.WorldToScreenPoint (obj.transform.position);
		float spriteWidth = obj.GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
		if(truePos.x > Screen.width + outOfScreenModifier || truePos.x < -Screen.width - outOfScreenModifier){
			return true;
		}
		return false;
	}

	void SpawnEnemy(){
		GameObject newEnemy = Instantiate (birdEnemy, gameObject.transform.position, Quaternion.identity) as GameObject;
		newEnemy.transform.position = calcSpawnPosition (newEnemy.gameObject.GetComponent<SpriteRenderer>().sprite);
		enemyList.Add (newEnemy);
	}
		
	// Use this for initialization
	void Start () {
		inScreenModifer = 20;
		outOfScreenModifier = inScreenModifer + 20;
		enemyList = new List<GameObject> ();
		for(int i = 0; i < amountOfEnemies; i++){
			enemyList.Add (new GameObject());
			enemyList [i] = Instantiate (birdEnemy, gameObject.transform.position, Quaternion.identity) as GameObject;
			enemyList [i].transform.position = calcSpawnPosition (enemyList[i].gameObject.GetComponent<SpriteRenderer>().sprite);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastIncrease += Time.deltaTime;
		if(timeSinceLastIncrease > spawnIncreaseTime){
			amountOfEnemies += 1;
			timeSinceLastIncrease = 0;
		}
		for(int i = 0; i < enemyList.Count; i++){
			if(outOfScreen(enemyList[i])){
				Destroy (enemyList[i]);
				enemyList.RemoveAt (i);
			}
		}
		if(enemyList.Count < amountOfEnemies){
			SpawnEnemy ();
		}
	}
}
