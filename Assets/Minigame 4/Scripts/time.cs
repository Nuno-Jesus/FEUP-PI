using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class time : MonoBehaviour
{
	public const float MAXTIME = 300.0f;
    public static float timeRemaining = MAXTIME;

    public static int lifes = 5;

    public Text CountDownTimer;

    public void changeScreen2()
    {
        SceneManager.LoadScene("DefeatScr");
    }

	void Start()
	{
		lifes = 5;
	}

    void Update()
    {
        if (timeRemaining > 0.1)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
			if (CountDownTimer != null)
				CountDownTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
            changeScreen2();
    }

	public static void resetTimer()
	{
		timeRemaining = MAXTIME;
	}
}
