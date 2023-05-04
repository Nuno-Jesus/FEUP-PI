using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowManyTracasEscaped : MonoBehaviour
{
    public Text scoreText;
    public void ShowHowManyHoles(){
        int tracasEscaped = PlayerPrefs.GetInt("TracasEscaped"); // the second parameter is the default value if the key does not exist
        Debug.Log("Tracas Escaped: " + tracasEscaped);
        // use tracasEscaped in your code
        scoreText.text = tracasEscaped.ToString();
    } 
}
