using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int Lives;
	public int Score;
	public AudioClip bunnydeath;
	public AudioClip menuMusic;
	public AudioClip gameMusic;
	public AudioClip overMusic;
	// Use this for initialization

	public static GameManager instance = null;


	public void PlayNewClip(AudioClip clip){
		if (this.gameObject.GetComponent<AudioSource> () != null) 
		{
			instance.GetComponent<AudioSource>().Stop ();
			instance.GetComponent<AudioSource>().clip = clip;
			instance.GetComponent<AudioSource>().Play ();
		}
	}
		
	void Awake () 
	{
		if(instance == null)
		{
			instance = this;
		} else if(instance != this){
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
		
		if(this.gameObject.GetComponent<AudioSource>() == null)
			this.gameObject.AddComponent<AudioSource> ();
		instance.Lives = 3;
		instance.Score = 0;
		PlayNewClip (menuMusic);
	}

	public void LoadMainMenu(){
		instance.PlayNewClip (menuMusic);
		SceneManager.LoadScene (0);
	}

	public void LoadGame(){
		instance.Lives = 3;
		instance.Score = 0;
		instance.PlayNewClip (gameMusic);
		SceneManager.LoadScene (1);
	}

	public void SetVolume(float vol){
		instance.GetComponent<AudioSource> ().volume = vol;
	}


	public void SetSound(bool sou){
		instance.GetComponent<AudioSource> ().mute = sou;
	}
	// Update is called once per frame
	void Update () 
	{
		if(SceneManager.GetActiveScene().buildIndex == 1){
			if(Lives <= 0){
				instance.PlayNewClip (overMusic);
				SceneManager.LoadScene (2);
			}
			GameObject.Find("BunnyTrust").GetComponent<Text>().text = Lives + "    Bunny Trust";
			GameObject.Find("Score").GetComponent<Text>().text = "Score: " + Score;
		}
		if(SceneManager.GetActiveScene().buildIndex == 2){
			GameObject.Find ("FinalScore").GetComponent<Text> ().text = "Score: " + Score;
		}
	}
}
