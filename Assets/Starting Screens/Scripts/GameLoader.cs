using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
	[SerializeField]
	public static string[] minigames = new string[4];
	
	[SerializeField]
	public static int minigameIndex;
	private const string FILENAME = "order.dat";
  
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
}