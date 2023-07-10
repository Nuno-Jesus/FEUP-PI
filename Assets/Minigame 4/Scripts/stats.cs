using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stats : MonoBehaviour
{
    public Text st;
    public int ra, me;
	
    void Start()
    {
        ra = QuizScoreManager.right_answers;
        me = QuizScoreManager.medalhas;

		//Set the current timestamp in int variable
		float currentDuration = Time.time;
		Debug.Log("Current time: " + currentDuration);
		
		//Calculate the duration of the game
		float tsec = currentDuration - QuizScoreManager.duration;
		int min = (int)(tsec / 60.0f);
		int sec = (int)tsec % 60;
		QuizScoreManager.scorelog("stats class");

        // st.text = string.Format("perguntas corretas: {0}/13\n\ntempo decorrido: {1}:{2}\n\nmedalhas: {3}/2", ra, min, sec, me);
		st.text = "perguntas corretas: " + ra + "/13\n\n";        
		st.text += "tempo decorrido : " + min + ":";
		if (sec < 10)
			st.text += "0" + sec + "\n\n";
		else
			st.text += sec + "\n\n";
		st.text += "medalhas: " + me + "/2";
    }

    public void show_medal() {
        if(me == 2)
		{
            if(ra >= 8)
                SceneManager.LoadScene("Gold");
            else if(ra >= 4)
                SceneManager.LoadScene("Silver");
            else
                SceneManager.LoadScene("Bronze");
        }
        else if(me == 1)
		{
            if(ra == 13)
                SceneManager.LoadScene("Gold");
            else if(ra >= 8)
                SceneManager.LoadScene("Silver");
            else
                SceneManager.LoadScene("Bronze");
        }
        else if(me == 0)
		{
            if(ra == 13)
                SceneManager.LoadScene("Silver");
            else
                SceneManager.LoadScene("Bronze");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
