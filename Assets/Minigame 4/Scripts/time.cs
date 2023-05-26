using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class time : MonoBehaviour
{
    public static float timeRemaining = 60;

    public static int lifes = 5;

    public Text CountDownTimer;

    public void changeScreen2()
    {
        SceneManager.LoadScene("VictoryScreen");
    }

    void Update()
    {
        if (timeRemaining > 0.1)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            CountDownTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            changeScreen2();
        }
    }
}
