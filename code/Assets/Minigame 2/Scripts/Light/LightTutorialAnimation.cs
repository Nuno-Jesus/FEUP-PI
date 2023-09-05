using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightTutorialAnimation : MonoBehaviour
{
	public Slider slider;
	public GameObject phone;
    public float coefficient;
	public float rotationSpeed;
	public float rotationZ;
	public float targetAngle;

    // Update is called once per frame
    void Update()
    {
        if (slider.value == slider.minValue)
			coefficient = 1;
		else if (slider.value == slider.maxValue)
			coefficient = -1;
		slider.value += coefficient * Time.deltaTime;

		if (coefficient == 1 && rotationZ < targetAngle)
		{
			rotationZ += Time.deltaTime * rotationSpeed;
			phone.transform.rotation = Quaternion.Euler(0, 0, -rotationZ);
		}
		else if (coefficient == -1 && rotationZ > -targetAngle)
		{	rotationZ -= Time.deltaTime * rotationSpeed;
			phone.transform.rotation = Quaternion.Euler(0, 0, -rotationZ);
		}
    }
}
