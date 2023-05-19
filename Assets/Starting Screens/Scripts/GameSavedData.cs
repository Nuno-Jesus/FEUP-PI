using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
 public sealed class GameSavedData
{
	[SerializeField]
	public string[] minigames = new string[4];
	
	[SerializeField]
	public int minigameIndex;
  
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

	public void loadNextMinigame()
	{
		SceneManager.LoadScene(minigames[minigameIndex++ % minigames.Length]);
	}	
}