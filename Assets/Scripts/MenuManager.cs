using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public Canvas MenuCanvas;
	public Canvas SettingsCanvas;

	void Awake()
	{
		MenuCanvas.enabled = true;
		SettingsCanvas.enabled = false;
	}

	public void ExitGame()
	{
		Application.Quit ();	
	}

	public void SettingsOn()
	{
		MenuCanvas.enabled = false;
		SettingsCanvas.enabled = true;
	}

	public void MainMenuOn()
	{
		MenuCanvas.enabled = true;
		SettingsCanvas.enabled = false;
	}

}
