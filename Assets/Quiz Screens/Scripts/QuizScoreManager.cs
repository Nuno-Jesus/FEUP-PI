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
    public static int medalhas = 2;
	public bool isright = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

	public void quizzScore()
    {

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
       	if (isright) {
            right_answers += 1;
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
}


