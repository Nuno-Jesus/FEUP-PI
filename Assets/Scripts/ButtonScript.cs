using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
	public Button button;
	public string nextScene;
    // Start is called before the first frame update

	void Start()
	{
		button.onClick.AddListener(onClick);
	}
    public void onClick()
	{
		SceneManager.LoadScene(nextScene);
	}
}
