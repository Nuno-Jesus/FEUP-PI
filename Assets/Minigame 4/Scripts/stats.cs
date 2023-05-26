using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stats : MonoBehaviour
{
    public Text st;
    public int ra, du , me;
    // Start is called before the first frame update
    void Start()
    {
        ra = QuizScoreManager.right_answers;
        du = QuizScoreManager.duration;
        me = QuizScoreManager.medalhas;
		//Set the current timestamp in int variable
		int currentDuration = (int)System.DateTime.Now.Ticks;
		
		//Calculate the duration of the game
		du = currentDuration - du;
		du = du / 10000000;

        st.text = string.Format("perguntas corretas: {0}/13\n\ntempo decorrido: {1}\n\nmedalhas: {2}/2", ra, du, me);        
    }

    public void show_medal() {
        if(me == 2){
            if(ra >= 8){
                SceneManager.LoadScene("Gold");
            }
            else if(ra >= 4){
                SceneManager.LoadScene("Silver");
            }
            else{
                SceneManager.LoadScene("Bronze");
            }
        }
        else if(me == 1){
            if(ra == 13){
                SceneManager.LoadScene("Gold");
            }
            else if(ra >= 8){
                SceneManager.LoadScene("Silver");
            }
            else{
                SceneManager.LoadScene("Bronze");
            }
        }
        else if(me == 0){
            if(ra == 13){
                SceneManager.LoadScene("Silver");
            }
            else{
                SceneManager.LoadScene("Bronze");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
