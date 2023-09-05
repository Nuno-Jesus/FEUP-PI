using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowManyTracasEscaped : MonoBehaviour
{
	public Text scoreText;
	public void ShowHowManyHoles()
	{
		int tracasEscaped = PlayerPrefs.GetInt("TracasEscaped"); // the second parameter is the default value if the key does not exist
		scoreText.text = tracasEscaped.ToString();
	}
}
