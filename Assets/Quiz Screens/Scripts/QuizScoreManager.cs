using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizScoreManager : MonoBehaviour
{
    public Text scoreText;

    static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseScore()
    {
        score += 100;
        scoreText.text = score.ToString();
    }

    public void DecreaseScore()
    {
        score -= 50;
        scoreText.text = score.ToString();
    }
}


