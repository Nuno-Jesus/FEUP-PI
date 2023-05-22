using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
	public float timer = 0;
	public const float MAXTIME = 52.0f;
	public Button button;

    void Update()
    {
        timer += Time.deltaTime;
		//If the time reaches the max time, the button is set to active
		if(timer >= MAXTIME)
			button.gameObject.SetActive(true);
    }
}
