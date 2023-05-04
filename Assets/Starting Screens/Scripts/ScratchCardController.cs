using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScratchCardController : MonoBehaviour
{
	public SceneLoader sceneLoader;
	public Text text;
    void Start()
    {
		sceneLoader.MinigameIndex = 0;
		text.text = sceneLoader.Minigames[0];
    }
}
