using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
	public Button button;
	public string nextScene;
	public bool isMinigameSwap;

	void Start()
	{
		//Get the sceneLoader from the assets
		if (button)
			button.onClick.AddListener(onClick);
	}

    public void onClick()
	{
		if (isMinigameSwap)			
			GameLoader.loadNextMinigame();
		else
			SceneManager.LoadScene(nextScene);
	}
	
	public void goingDownPath()
	{
		Debug.Log("Minigame 1");
		GameLoader.minigames = null;
		GameLoader.minigames = new string[4];
		GameLoader.minigames[0] = "InsectsStartScene";
		GameLoader.minigames[1] = "LightStartScene";
		GameLoader.minigames[2] = "EarthquakeStartScene";
		GameLoader.minigames[3] = "EraserStartScene";
		Text text = GameObject.FindGameObjectWithTag("debug").GetComponent<Text>();
		text.text = GameLoader.minigames[0] + "\n" + 
					GameLoader.minigames[1] + "\n" + 
					GameLoader.minigames[2] + "\n" + 
					GameLoader.minigames[3];
	}

	public void goingUpPath()
	{
		Debug.Log("Minigame 2");
		GameLoader.minigames = null;
		GameLoader.minigames = new string[4];
		GameLoader.minigames[0] = "EarthquakeStartScene";
		GameLoader.minigames[1] = "LightStartScene";
		GameLoader.minigames[2] = "InsectsStartScene";
		GameLoader.minigames[3] = "EraserStartScene";
		Text text = GameObject.FindGameObjectWithTag("debug").GetComponent<Text>();
		text.text = GameLoader.minigames[0] + "\n" + 
					GameLoader.minigames[1] + "\n" + 
					GameLoader.minigames[2] + "\n" + 
					GameLoader.minigames[3];
	}
}
