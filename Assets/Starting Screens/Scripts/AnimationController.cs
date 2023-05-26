using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
	public float timer = 0;
	public const float MAX_TIME = 52.0f;
	public Button button;

	void Start()
	{
		//Set the device orientation to landscape counter clockwise
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

    void Update()
    {
        timer += Time.deltaTime;
		//If the time reaches the max time, the button is set to active
		if(timer >= MAX_TIME)
			button.gameObject.SetActive(true);
    }
}
