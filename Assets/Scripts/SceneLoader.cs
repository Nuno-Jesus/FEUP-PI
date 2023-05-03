using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneLoader : ScriptableObject
{
	[SerializeField]
	private string[] minigames = new string[3];
	
	[SerializeField]
	private int minigameIndex = 0;

	public void Start()
	{
		minigameIndex = 0;
	}
  
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
}
