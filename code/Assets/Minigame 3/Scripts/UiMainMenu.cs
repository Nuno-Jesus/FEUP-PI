using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour
{
    [SerializeField] Button _StartGame;

    void Start(){
        _StartGame.onClick.AddListener(StartNewGame);
    }

    private void StartNewGame(){
        ScenesManager.Instance.LoadNewGame();
    }
}
