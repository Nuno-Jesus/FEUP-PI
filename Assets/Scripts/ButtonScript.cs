using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
	public Button button;
	public string nextScene;
	public bool isPlayerSwap;
	public SceneLoader sceneLoader;

	void Start()
	{
		if (button)
			button.onClick.AddListener(onClick);
	}

    public void onClick()
	{
		if (isPlayerSwap)
		{
			sceneLoader.MinigameIndex++;
			if (sceneLoader.MinigameIndex > 2)
				sceneLoader.MinigameIndex = 0;
			SceneManager.LoadScene(sceneLoader.Minigames[sceneLoader.MinigameIndex]);
		}
		else
			SceneManager.LoadScene(nextScene);
	}

	public void onMinigame1()
	{
		Debug.Log("Minigame 1");
		sceneLoader.Minigames = null;
		sceneLoader.Minigames = new string[3];
		sceneLoader.Minigames[0] = "Test Minigame 1";
		sceneLoader.Minigames[1] = "Test Minigame 2";
		sceneLoader.Minigames[2] = "Test Minigame 3";
	}

	public void onMinigame2()
	{
		Debug.Log("Minigame 2");
		sceneLoader.Minigames = null;
		sceneLoader.Minigames = new string[3];
		sceneLoader.Minigames[0] = "Test Minigame 2";
		sceneLoader.Minigames[1] = "Test Minigame 1";
		sceneLoader.Minigames[2] = "Test Minigame 3";
	}
}
