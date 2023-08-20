using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetScore : MonoBehaviour
{
	public Text scoreText;
	public Text pharseText;

	void Start()
	{
		if (SceneManager.GetActiveScene().name == "GameOverGorPlayAgain")
			ShowHowManyHoles();
		else if (SceneManager.GetActiveScene().name == "GameOverSceneYouWon")
			ShowScore();
	}

	public void ShowScore()
	{
		int score = PlayerPrefs.GetInt("Score");
		scoreText.text = score.ToString();
	}

	[ContextMenu("HowManyHoles")]
	public void ShowHowManyHoles()
	{
		int score = PlayerPrefs.GetInt("Score");
		int tracasEscaped = 29 - score;
		string scorePhrase;

		if (tracasEscaped > 1)
			scorePhrase = "Boa! Apanharam uma série de traças. Só deixaram fugir " + tracasEscaped.ToString() + " tracas. Nós sabemos que conseguem fazer melhor!";
		else
			scorePhrase = "Boa! Apanharam uma série de traças. Só deixaram fugir " + tracasEscaped.ToString() + " traca. Nós sabemos que conseguem fazer melhor!";
		pharseText.text = scorePhrase;
		scoreText.text = tracasEscaped.ToString();
	}

	[ContextMenu("GoBackGame")]
	public void GoBackToGame()
	{
		SceneManager.LoadScene("GameScene");
	}
}
