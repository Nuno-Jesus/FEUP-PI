using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Weaponchoice : MonoBehaviour
{
	public Button button;

	void Start()
	{
		if (button)
			button.onClick.AddListener(onClick);
	}

    public void onClick()
	{
		if (QuizScoreManager.score >= 300)			
			SceneManager.LoadScene("Desintegrador");
		else
			SceneManager.LoadScene("Fisga");
	}
}

