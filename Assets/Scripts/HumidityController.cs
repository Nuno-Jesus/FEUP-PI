using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumidityController : MonoBehaviour
{
    public Sprite[] pictureFrames;
    public GameObject picture;

    public Slider humiditySlider;
    public Slider temperatureSlider;
    private KeyValuePair<float, float>[] humidityRanges;
    private KeyValuePair<float, float>[] temperatureRanges;

	public int correctFrame = 2;
    public int currentFrame = 0;

    void Start()
    {
        humidityRanges = new KeyValuePair<float, float>[6];
        humidityRanges[0] = new KeyValuePair<float, float>(0.0f, 34.9f);
        humidityRanges[1] = new KeyValuePair<float, float>(35.0f, 39.9f);
        humidityRanges[2] = new KeyValuePair<float, float>(40.0f, 59.9f);
        humidityRanges[3] = new KeyValuePair<float, float>(60.0f, 64.9f);
        humidityRanges[4] = new KeyValuePair<float, float>(65.0f, 79.9f);
        humidityRanges[5] = new KeyValuePair<float, float>(80.0f, 100.0f);

        temperatureRanges = new KeyValuePair<float, float>[6];
        temperatureRanges[0] = new KeyValuePair<float, float>(0.0f, 4.9f);
        temperatureRanges[1] = new KeyValuePair<float, float>(5.0f, 9.9f);
        temperatureRanges[2] = new KeyValuePair<float, float>(10.0f, 14.9f);
        temperatureRanges[3] = new KeyValuePair<float, float>(15.0f, 24.9f);
        temperatureRanges[4] = new KeyValuePair<float, float>(25.0f, 39.9f);
        temperatureRanges[5] = new KeyValuePair<float, float>(40.0f, 50.0f);
    }

	bool between(float n, float a, float b)
	{
		return (n >= a && n <= b);
	}

	int getPictureFrame(Slider slider, KeyValuePair<float, float>[] ranges)
	{
        for (int i = 0; i < 6; i++)
			if (between(slider.value, ranges[i].Key, ranges[i].Value))
				return i;
		return 0;
	}

    void Update()
    {   
		Debug.Log("Humidity Value: " + humiditySlider.value);
		Debug.Log("Temperature Value: " + temperatureSlider.value);

		int	tFrame = getPictureFrame(temperatureSlider, temperatureRanges);     
		int	hFrame = getPictureFrame(humiditySlider, humidityRanges);
		if (tFrame == hFrame)
		{
			currentFrame = tFrame;
			picture.GetComponent<SpriteRenderer>().sprite = pictureFrames[currentFrame];
		}
    }
}
