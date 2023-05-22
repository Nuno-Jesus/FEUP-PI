using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    public float timeRemaining = 60;

    public Text CountDownTimer;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            CountDownTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            // Game over logic
            CountDownTimer.text = "TIME'S UP!!!";
        }
    }
}
