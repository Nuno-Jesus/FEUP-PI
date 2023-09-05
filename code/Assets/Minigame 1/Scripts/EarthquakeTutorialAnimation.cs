using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeTutorialAnimation : MonoBehaviour
{
	public GameObject phone;
	public float rotationSpeed;
	public float rotationZ;
	public float targetAngle;
	public float timer = 0.0f;
	public float waitTime;

    void Update()
    {
		if (rotationZ < Mathf.Abs(targetAngle))
		{
			rotationZ += Time.deltaTime * rotationSpeed;
			phone.transform.rotation = Quaternion.Euler(0, 0, -rotationZ);
		}
		else
		{
			timer += Time.deltaTime;
			// if (timer > waitTime)
			// {
			// 	timer = 0.0f;
			// 	rotationZ = 0;
			// 	phone.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
			// }
		}
    }
}
