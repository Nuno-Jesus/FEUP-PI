using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScenesManager : MonoBehaviour
{   
    public static ScenesManager Instance;

    private void Awake(){
        Instance = this;
    }

    public void LoadNewGame(){
        SceneManager.LoadScene("GameScene");
    }
}
 