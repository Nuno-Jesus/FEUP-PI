using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class RestartScript : MonoBehaviour
{
	public int playerScore;
	public int TracasEscaped;
	public int numoflarvas1;

	[ContextMenu("Increase Score")]
	public void addScore()
	{
		playerScore = Mathf.Clamp(playerScore + 1, 0, SpawnTracaScript.MAXSCORE);
		Debug.Log("Current score: " + playerScore);
		string sessionKey = System.DateTime.Now.ToString("yyyyMMddHHmmss");
		PlayerPrefs.SetInt(sessionKey, playerScore);
	}

	[ContextMenu("Restart Game")]
	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
		playerScore = 0;
	}
	public void GameOver(int playerScore)
	{
		if (playerScore < SpawnTracaScript.MAXSCORE - 5)
		{
			string sessionKey = System.DateTime.Now.ToString("yyyyMMddHHmmss");
			PlayerPrefs.SetInt(sessionKey, playerScore);
			PlayerPrefs.SetString("SessionKey", sessionKey);
			SceneManager.LoadScene("GameOverGorPlayAgain");
		}
		else if (playerScore >= SpawnTracaScript.MAXSCORE - 5 && playerScore < SpawnTracaScript.MAXSCORE)
		{
			string sessionKey = System.DateTime.Now.ToString("yyyyMMddHHmmss");
			PlayerPrefs.SetInt(sessionKey, playerScore);
			PlayerPrefs.SetString("SessionKey", sessionKey);
			SceneManager.LoadScene("GameOverGorPlayAgain");
		}
		else if (playerScore >= SpawnTracaScript.MAXSCORE)
		{
			string sessionKey = System.DateTime.Now.ToString("yyyyMMddHHmmss");
			PlayerPrefs.SetInt(sessionKey, playerScore);
			PlayerPrefs.SetString("SessionKey", sessionKey);
			QuizScoreManager.medalhas += 1;
			SceneManager.LoadScene("GameOverSceneYouWon");
		}
	}

	public void GameOverbyLarvas(int numoflarvas)
	{
		if (numoflarvas == 10)
			SceneManager.LoadScene("GameOverScreenByLarvas");
	}

	public void GoBackToGame()
	{
		SceneManager.LoadScene("GameScene");
		Time.timeScale = 1;
		playerScore = 0;
	}
}
