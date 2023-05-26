using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Weaponchoice : MonoBehaviour
{
	public Button button;

	void Start()
	{
		if (button)
			button.onClick.AddListener(onClick);
	}

    public void onClick()
	{
		if (QuizScoreManager.score >= 300)			
			SceneManager.LoadScene("Desintegrador");
		else
			SceneManager.LoadScene("Fisga");
	}

    public void goingDownPath()
	{
		GameLoader.minigames = null;
		GameLoader.minigames = new string[4];
		GameLoader.minigames[0] = "InsectsStartScene";
		GameLoader.minigames[1] = "LightStartScene";
		GameLoader.minigames[2] = "EarthquakeStartScene";
		GameLoader.minigames[3] = "EraserStartScene";
		Text text = GameObject.FindGameObjectWithTag("debug").GetComponent<Text>();
		text.text = "1 -> Insects Minigame\n" + 
					"2 -> Light Minigame\n" + 
					"3 -> Earthquake Minigame\n" + 
					"4 -> Eraser Minigame\n";
	}

	public void goingUpPath()
	{
		GameLoader.minigames = null;
		GameLoader.minigames = new string[4];
		GameLoader.minigames[0] = "EarthquakeStartScene";
		GameLoader.minigames[1] = "LightStartScene";
		GameLoader.minigames[2] = "InsectsStartScene";
		GameLoader.minigames[3] = "EraserStartScene";
		Text text = GameObject.FindGameObjectWithTag("debug").GetComponent<Text>();
		text.text = "1 -> Earthquake Minigame\n" + 
					"2 -> Light Minigame\n" + 
					"3 -> Insects Minigame\n" + 
					"4 -> Eraser Minigame\n";
	}
}

