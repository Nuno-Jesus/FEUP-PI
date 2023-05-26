using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HumidityController : MonoBehaviour
{
    public Sprite[] pictureFrames;
    public Slider humiditySlider;
    public GameObject humidityPicture;
    private KeyValuePair<float, float>[] temperatureRanges;
    public int humidityCurrentFrame = 5;
    public const int humidityCorrectFrame = 2;

    public Slider temperatureSlider;
    public GameObject temperaturePicture;
    private KeyValuePair<float, float>[] humidityRanges;
    public int temperatureCurrentFrame = 0;
    public const int temperatureCorrectFrame = 2;

	public AudioSource temperatureCorrectSoundSource;
	public AudioSource humidityCorrectSoundSource;

    void Start()
    {
        humidityRanges = new KeyValuePair<float, float>[6];
        humidityRanges[0] = new KeyValuePair<float, float>(0.0f, 34.99f);
        humidityRanges[1] = new KeyValuePair<float, float>(35.0f, 39.99f);
        humidityRanges[2] = new KeyValuePair<float, float>(40.0f, 59.99f);
        humidityRanges[3] = new KeyValuePair<float, float>(60.0f, 64.99f);
        humidityRanges[4] = new KeyValuePair<float, float>(65.0f, 79.99f);
        humidityRanges[5] = new KeyValuePair<float, float>(80.0f, 100.0f);

        humiditySlider.value = humidityRanges[humidityCurrentFrame].Key;
        
        temperatureRanges = new KeyValuePair<float, float>[6];
        temperatureRanges[0] = new KeyValuePair<float, float>(0.0f, 4.99f);
        temperatureRanges[1] = new KeyValuePair<float, float>(5.0f, 9.99f);
        temperatureRanges[2] = new KeyValuePair<float, float>(10.0f, 14.99f);
        temperatureRanges[3] = new KeyValuePair<float, float>(15.0f, 24.99f);
        temperatureRanges[4] = new KeyValuePair<float, float>(25.0f, 39.99f);
        temperatureRanges[5] = new KeyValuePair<float, float>(40.0f, 50.0f);

        temperatureSlider.value = temperatureRanges[temperatureCurrentFrame].Key;    
    }

    void Update()
    {   
		if (hasEnteredCorrectTemperatureRange() && !temperatureCorrectSoundSource.isPlaying)
			temperatureCorrectSoundSource.Play();
		else if (!hasEnteredCorrectTemperatureRange())
			temperatureCorrectSoundSource.Stop();
		
		if (hasEnteredCorrectHumidityRange() && !humidityCorrectSoundSource.isPlaying)
			humidityCorrectSoundSource.Play();
		else if (!hasEnteredCorrectHumidityRange())
			humidityCorrectSoundSource.Stop();

		temperatureCurrentFrame = getPictureFrame(temperatureSlider, temperatureRanges);     
        temperaturePicture.GetComponent<SpriteRenderer>().sprite = pictureFrames[temperatureCurrentFrame];
		
		humidityCurrentFrame = getPictureFrame(humiditySlider, humidityRanges);
        humidityPicture.GetComponent<SpriteRenderer>().sprite = pictureFrames[humidityCurrentFrame];
	}

	bool between(float n, float a, float b)
	{
		return (n >= a && n <= b);
	}

	bool hasEnteredCorrectHumidityRange()
	{
		return (humidityCorrectFrame == humidityCurrentFrame);
	}

	bool hasEnteredCorrectTemperatureRange()
	{
		return (temperatureCorrectFrame == temperatureCurrentFrame);
	}

	public bool hasEnteredCorrectRange()
	{
		return (hasEnteredCorrectHumidityRange() && hasEnteredCorrectTemperatureRange());
	}

	int getPictureFrame(Slider slider, KeyValuePair<float, float>[] ranges)
	{
        for (int i = 0; i < 6; i++)
			if (between(slider.value, ranges[i].Key, ranges[i].Value))
				return i;
		return 0;
	}
}
