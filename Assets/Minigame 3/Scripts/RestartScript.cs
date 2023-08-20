using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
	public int playerScore;
	public int TracasEscaped;
	public int numoflarvas1;

	[ContextMenu("Increase Score")]
	public void addScore()
	{
		playerScore += 1;
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
		if (playerScore >= 39 && playerScore <= 44)
		{
			string sessionKey = System.DateTime.Now.ToString("yyyyMMddHHmmss");
			PlayerPrefs.SetInt(sessionKey, playerScore);
			PlayerPrefs.SetString("SessionKey", sessionKey);
			SceneManager.LoadScene("GameOverGorPlayAgain");
		}
		else if (playerScore > 44)
		{
			string sessionKey = System.DateTime.Now.ToString("yyyyMMddHHmmss");
			PlayerPrefs.SetInt(sessionKey, playerScore);
			PlayerPrefs.SetString("SessionKey", sessionKey);
			QuizScoreManager.medalhas += 1;
			SceneManager.LoadScene("GameOverSceneYouWon");
		}
		else if (playerScore < 39)
		{
			string sessionKey = System.DateTime.Now.ToString("yyyyMMddHHmmss");
			PlayerPrefs.SetInt(sessionKey, playerScore);
			PlayerPrefs.SetString("SessionKey", sessionKey);
			SceneManager.LoadScene("GameOverGorPlayAgain");
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
