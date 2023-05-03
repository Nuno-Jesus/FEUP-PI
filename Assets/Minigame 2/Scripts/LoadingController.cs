using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
	public float maxTime;
    void Start()
    {
		gameObject.GetComponent<Slider>().value = 0;
    }

    // Update is called once per frame
    void Update()
    {
		gameObject.GetComponent<Slider>().value += Time.deltaTime;
		if (gameObject.GetComponent<Slider>().value >= maxTime)
			Destroy(gameObject);
    }
}
