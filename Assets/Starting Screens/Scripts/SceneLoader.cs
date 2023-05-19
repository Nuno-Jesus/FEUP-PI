using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="ScriptableSaver", menuName ="SaveSystem")]
public class SceneLoader : MonoBehaviour
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
		//Debug the previous minigame with the index and name
		Debug.Log("Previous Minigame " + minigameIndex + ": " + minigames[minigameIndex]);
		//Debug the minigames.length
		Debug.Log("Minigames Length: " + minigames.Length);

		SceneLoader.minigameIndex++;
		//Debug the next minigame with the index and name
		Debug.Log("Next Minigame " + minigameIndex + ": " + minigames[SceneLoader.minigameIndex % SceneLoader.minigames.Length]);
		SceneManager.LoadScene(minigames[(SceneLoader.minigameIndex - 1) % SceneLoader.minigames.Length]);
	}
}