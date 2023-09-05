using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [ContextMenu("BackToGame")]
    public void GoBackToGame(){
        SceneManager.LoadScene("GameScene");
    }
}
