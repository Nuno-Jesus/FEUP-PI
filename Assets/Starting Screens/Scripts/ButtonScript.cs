using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
	public Button button;
	public string nextScene;
	public bool isMinigameSwap;

	void Start()
	{
		if (button)
			button.onClick.AddListener(onClick);
	}

    public void onClick()
	{
		if (isMinigameSwap)			
			GameLoader.loadNextMinigame();
		else
			SceneManager.LoadScene(nextScene);
	}
	
	public void goingDownPath()
	{
		GameLoader.setInsectsFirst();
		Text text = GameObject.FindGameObjectWithTag("debug").GetComponent<Text>();
		text.text = "1º: Jogos dos Insectos\n" + 
					"2º: Jogo da Luz/Humidade\n" + 
					"3º: Jogo do Terramoto\n" + 
					"4º: Jogo Final";
	}

	public void goingUpPath()
	{
		GameLoader.setEarthquakeFirst();
		Text text = GameObject.FindGameObjectWithTag("debug").GetComponent<Text>();
		text.text = "1º: Jogo do Terramoto\n" + 
					"2º: Jogo da Luz/Humidade\n" + 
					"3º: Jogos dos Insectos\n" + 
					"4º: Jogo Final";
	}
}
