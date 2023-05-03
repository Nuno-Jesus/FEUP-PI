using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HiddenConfigs : MonoBehaviour
{
	public int numclicks = 0;
    
	public void onMegaphoneClick()
	{
		numclicks++;
		if (numclicks == 10)
			SceneManager.LoadScene("Hidden Configs");
	}
}
