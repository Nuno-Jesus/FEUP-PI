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
			sceneLoader.loadNextMinigame();
		else
			SceneManager.LoadScene(nextScene);
	}

	public void onMinigame1()
	{
		Debug.Log("Minigame 1");
		sceneLoader.Minigames = null;
		sceneLoader.Minigames = new string[4];
		sceneLoader.Minigames[0] = "InsectsStartScene";
		sceneLoader.Minigames[1] = "LightStartScene";
		sceneLoader.Minigames[2] = "Test Minigame 3";
		sceneLoader.Minigames[3] = "Test Minigame 4";
	}

	public void onMinigame2()
	{
		Debug.Log("Minigame 2");
		sceneLoader.Minigames = null;
		sceneLoader.Minigames = new string[4];
		sceneLoader.Minigames[0] = "LightStartScene";
		sceneLoader.Minigames[1] = "InsectsStartScene";
		sceneLoader.Minigames[2] = "Test Minigame 3";
		sceneLoader.Minigames[3] = "Test Minigame 4";
	}
}
