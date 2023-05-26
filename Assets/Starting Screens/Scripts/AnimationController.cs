using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
	public float timer = 0;
	public float maxTime;

	public const float MAX_TIME = 52.0f;
	public Button button;

    void Update()
    {
        timer += Time.deltaTime;
		//If the time reaches the max time, the button is set to active
		if(timer >= maxTime)
			button.gameObject.SetActive(true);
    }
}
