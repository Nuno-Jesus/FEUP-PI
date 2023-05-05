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
	public SceneLoader MinigameLoader;

	void Start()
	{
		if (button)
			button.onClick.AddListener(onClick);
	}

    public void onClick()
	{
		if (isMinigameSwap)			
			MinigameLoader.loadNextMinigame();
		else
			SceneManager.LoadScene(nextScene);
	}

	public void onMinigame1()
	{
		Debug.Log("Minigame 1");
		MinigameLoader.Minigames = null;
		MinigameLoader.Minigames = new string[4];
		MinigameLoader.Minigames[0] = "InsectsStartScene";
		MinigameLoader.Minigames[1] = "LightStartScene";
		MinigameLoader.Minigames[2] = "EarthquakeStartScene";
		MinigameLoader.Minigames[3] = "EraserStartScene";
	}

	public void onMinigame2()
	{
		Debug.Log("Minigame 2");
		MinigameLoader.Minigames = null;
		MinigameLoader.Minigames = new string[4];
		MinigameLoader.Minigames[0] = "LightStartScene";
		MinigameLoader.Minigames[1] = "InsectsStartScene";
		MinigameLoader.Minigames[2] = "EarthquakeStartScene";
		MinigameLoader.Minigames[3] = "EraserStartScene";
	}
}
