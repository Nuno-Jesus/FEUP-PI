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

	public static void loadNextMinigame()
	{
		GameLoader.minigameIndex++;
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
}