using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class SceneLoader : ScriptableObject
{
	[SerializeField]
	private string[] minigames = new string[3];
	
	[SerializeField]
	private int minigameIndex;
  
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
		// if (minigameIndex < 0)
		// {
		// 	minigameIndex = 0;
		// 	SceneManager.LoadScene(minigames[0]);
		// }
		// else 
		// {
		// 	minigameIndex++;
		// 	if (minigameIndex > 2)
		// 		minigameIndex = 0;
		// 	SceneManager.LoadScene(minigames[minigameIndex]);
		// }
		SceneManager.LoadScene(minigames[minigameIndex++ % 3]);
	}	
}
