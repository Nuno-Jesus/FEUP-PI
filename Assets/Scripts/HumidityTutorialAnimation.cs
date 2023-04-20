using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumidityTutorialAnimation : MonoBehaviour
{
	public GameObject slider1;
	public GameObject slider2;
	public GameObject phone;
    public float coefficient;
	public float scaleSpeed;
	public float maxTime;
	public float timer;

    void Update()
    {
        if (getSlider(slider1).value == getSlider(slider1).minValue)
			coefficient = 1;
		else if (getSlider(slider1).value == getSlider(slider1).maxValue)
			coefficient = -1;
		getSlider(slider1).value += coefficient * Time.deltaTime;
		getSlider(slider2).value += coefficient * Time.deltaTime;
		timer += Time.deltaTime;

		if (timer >= maxTime)
		{
			slider1.SetActive(true);
			slider2.SetActive(true);
			return ;
		}

		phone.transform.localScale = new Vector3(
			phone.transform.localScale.x + Time.deltaTime * scaleSpeed,
			phone.transform.localScale.y + Time.deltaTime * scaleSpeed,
			1
		);
    }

	Slider getSlider(GameObject slider)
	{
		return slider.GetComponent<Slider>();
	}
}
