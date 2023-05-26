using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    //public GameObject gameOverScreen;
    //public GameObject gameOverbyLarvas;
    //public GameObject gameOverScreenYouWon;
    //public Text scoreText;
    public int playerScore;
    //public Text textFinale;
    //public Text textFinaleForLarvas;
    public int TracasEscaped;
    public int numoflarvas1;
    private bool ContinueGame; // add this line

    [ContextMenu("Increase Score")]
    public void addScore()
{
    playerScore += 1;
    //scoreText.text = playerScore.ToString();
    // Set the score value
    string sessionKey = System.DateTime.Now.ToString("yyyyMMddHHmmss");
    PlayerPrefs.SetInt(sessionKey, playerScore);
}

    [ContextMenu("Restart Game")]
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        playerScore = 0;
        ContinueGame = true; // add this line
    }
    public void GameOver(int playerScore)
    {
        if(playerScore>=24 && playerScore<29){
            string sessionKey = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            PlayerPrefs.SetInt(sessionKey, playerScore);
            PlayerPrefs.SetString("SessionKey", sessionKey);
            SceneManager.LoadScene("GameOverGorPlayAgain");
        } else if(playerScore==29){
            string sessionKey = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            PlayerPrefs.SetInt(sessionKey, playerScore);
            PlayerPrefs.SetString("SessionKey", sessionKey);
			QuizScoreManager.medalhas += 1;
            SceneManager.LoadScene("GameOverSceneYouWon");
        } else if(playerScore<24){
            string sessionKey = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            PlayerPrefs.SetInt(sessionKey, playerScore);
            PlayerPrefs.SetString("SessionKey", sessionKey);
            SceneManager.LoadScene("GameOverGorPlayAgain");
        }
    }

    public void GameOverbyLarvas(int numoflarvas){
        if(numoflarvas==10){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            SceneManager.LoadScene("GameOverScreenByLarvas");
            numoflarvas=0;
        }
    }

    public void GoBackToGame(){
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
        playerScore = 0;
        ContinueGame = true;
        Debug.Log("Game Restarted");
    }
}
