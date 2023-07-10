using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizScoreManager : MonoBehaviour
{
    public Text scoreText;

    public Button b1;
    public Button b2;
    public string nextscene;

    public static int right_options = 0;
    public static int score = 0;
    public static int right_answers = 0;
    public static int duration = 0;
    public static int medalhas = 0;
	public bool isright = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

	public void setfalse()
    {
        isright = false;
    }

    public void IncreaseOptions1()
    {
        right_options += 1;
        b1.interactable = false;
        if(right_options == 2){
            right_options = 0;
            SceneManager.LoadScene(nextscene);
        }
    }

    public void IncreaseOptions2()
    {
        right_options += 1;
        b2.interactable = false;
        if(right_options == 2){
            right_options = 0;
            SceneManager.LoadScene(nextscene);
        }
    }

    public void IncreaseScore()
    {
       	if (isright)
		{
            right_answers += 1;
			scorelog("IncreaseScore: right answer");
        }
        else { 
            isright = true;
        }
        score += 100;
        scoreText.text = score.ToString();
    }

    public void DecreaseScore()
    {
        score -= 50;
        scoreText.text = score.ToString();
    }

	//Load the medal scene if the score of this minigame was 300
	public void showLightResult()
	{
		if (score >= 500)
		{
			QuizScoreManager.medalhas += 1;
			SceneManager.LoadScene("BestResult");
		}
		else
			SceneManager.LoadScene("GoodResult");
	}

	public static void scorelog(string function)
	{
		Debug.Log(" ============= DEBUGGING FROM: " + function + " ============= ");
		Debug.Log("Score: " + score);
		Debug.Log("Duration: " + duration);
		Debug.Log("Medalhas: " + medalhas);
		// Debug.Log("Is Right: " + isright);
		Debug.Log("Right Answers: " + right_answers);
		Debug.Log("Right Options: " + right_options);
	}
}


