using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
	[SerializeField]
	public static string[] minigames;
	
	[SerializeField]
	public static int minigameIndex;

	public static string[] shields =
	{
		"ShieldStage1Scene",
		"ShieldStage2Scene",
		"ShieldStage3Scene",
		"ShieldStage4Scene"
	};

	public string[] Minigames
	{
		get { return minigames; }
		set { minigames = value; }
	}

	public int MinigameIndex
	{
		get { return minigameIndex; }
		set { minigameIndex = value; }
	}

	public static void loadNextShieldFrame()
	{
		SceneManager.LoadScene(shields[(GameLoader.minigameIndex - 1) % shields.Length]);
	}

	public static void loadNextMinigame()
	{
		GameLoader.minigameIndex++;
		if (minigames[(GameLoader.minigameIndex - 1) % GameLoader.minigames.Length] == "EraserStartScene")
			QuizScoreManager.right_answers_before_last_game = QuizScoreManager.right_answers;
		SceneManager.LoadScene(minigames[(GameLoader.minigameIndex - 1) % GameLoader.minigames.Length]);
	}

	public static void setInsectsFirst()
	{
		GameLoader.minigames = null;
		GameLoader.minigames = new string[4];
		GameLoader.minigames[0] = "InsectsStartScene";
		GameLoader.minigames[1] = "LightStartScene";
		GameLoader.minigames[2] = "EarthquakeStartScene";
		GameLoader.minigames[3] = "EraserStartScene";
	}
	public static void setEarthquakeFirst()
	{
		GameLoader.minigames = null;
		GameLoader.minigames = new string[4];
		GameLoader.minigames[0] = "EarthquakeStartScene";
		GameLoader.minigames[1] = "LightStartScene";
		GameLoader.minigames[2] = "InsectsStartScene";
		GameLoader.minigames[3] = "EraserStartScene";
	}

	public void resetCode()
	{
		Code.code = null;
		Code.code = "";
	}

	public void resetRightAnswers()
	{
		QuizScoreManager.right_answers = QuizScoreManager.right_answers_before_last_game;
	}
}