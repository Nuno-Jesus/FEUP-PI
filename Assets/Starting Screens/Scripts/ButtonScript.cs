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
			SceneLoader.loadNextMinigame();
		else
			SceneManager.LoadScene(nextScene);
	}
	
	public void goingDownPath()
	{
		Debug.Log("Minigame 1");
		SceneLoader.minigames = null;
		SceneLoader.minigames = new string[4];
		SceneLoader.minigames[0] = "InsectsStartScene";
		SceneLoader.minigames[1] = "LightStartScene";
		SceneLoader.minigames[2] = "EarthquakeStartScene";
		SceneLoader.minigames[3] = "EraserStartScene";
		Text text = GameObject.FindGameObjectWithTag("debug").GetComponent<Text>();
		text.text = SceneLoader.minigames[0] + "\n" + 
					SceneLoader.minigames[1] + "\n" + 
					SceneLoader.minigames[2] + "\n" + 
					SceneLoader.minigames[3];
	}

	public void goingUpPath()
	{
		Debug.Log("Minigame 2");
		SceneLoader.minigames = null;
		SceneLoader.minigames = new string[4];
		SceneLoader.minigames[0] = "EarthquakeStartScene";
		SceneLoader.minigames[1] = "LightStartScene";
		SceneLoader.minigames[2] = "InsectsStartScene";
		SceneLoader.minigames[3] = "EraserStartScene";
		Text text = GameObject.FindGameObjectWithTag("debug").GetComponent<Text>();
		text.text = SceneLoader.minigames[0] + "\n" + 
					SceneLoader.minigames[1] + "\n" + 
					SceneLoader.minigames[2] + "\n" + 
					SceneLoader.minigames[3];
	}
}
