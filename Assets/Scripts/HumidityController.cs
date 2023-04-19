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
    public int humidityCorrectFrame = 2;

    public Slider temperatureSlider;
    public GameObject temperaturePicture;
    private KeyValuePair<float, float>[] humidityRanges;
    public int temperatureCurrentFrame = 0;
    public int temperatureCorrectFrame = 2;

	public Slider loadingHumiditySlider;
	public Slider loadingTemperatureSlider;
	private Slider loadingHumiditySliderClone;
	private Slider loadingTemperatureSliderClone;
	private bool wasLoadingRendered = false;
	public AudioSource temperatureCorrectSoundSource;
	public AudioSource humidityCorrectSoundSource;
	public Canvas canvas;

    void Start()
    {
        humidityRanges = new KeyValuePair<float, float>[6];
        humidityRanges[0] = new KeyValuePair<float, float>(0.0f, 34.9f);
        humidityRanges[1] = new KeyValuePair<float, float>(35.0f, 39.9f);
        humidityRanges[2] = new KeyValuePair<float, float>(40.0f, 59.9f);
        humidityRanges[3] = new KeyValuePair<float, float>(60.0f, 64.9f);
        humidityRanges[4] = new KeyValuePair<float, float>(65.0f, 79.9f);
        humidityRanges[5] = new KeyValuePair<float, float>(80.0f, 100.0f);

        humiditySlider.value = humidityRanges[humidityCurrentFrame].Key;
        
        temperatureRanges = new KeyValuePair<float, float>[6];
        temperatureRanges[0] = new KeyValuePair<float, float>(0.0f, 4.9f);
        temperatureRanges[1] = new KeyValuePair<float, float>(5.0f, 9.9f);
        temperatureRanges[2] = new KeyValuePair<float, float>(10.0f, 14.9f);
        temperatureRanges[3] = new KeyValuePair<float, float>(15.0f, 24.9f);
        temperatureRanges[4] = new KeyValuePair<float, float>(25.0f, 39.9f);
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
		
		if (hasEnteredCorrectHumidityRange() && hasEnteredCorrectTemperatureRange())
			checkSuccess();

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

	int getPictureFrame(Slider slider, KeyValuePair<float, float>[] ranges)
	{
        for (int i = 0; i < 6; i++)
			if (between(slider.value, ranges[i].Key, ranges[i].Value))
				return i;
		return 0;
	}

	void checkSuccess()
	{
		if (!wasLoadingRendered)
		{
			loadingHumiditySliderClone = Instantiate(loadingHumiditySlider, canvas.transform);
			// loadingTemperatureSliderClone = Instantiate(loadingTemperatureSlider, canvas.transform);
			wasLoadingRendered = true;
		}
		if (loadingHumiditySliderClone.value < 3.0f /* && loadingTemperatureSliderClone.value < 3.0f */)
			return ;
		SceneManager.LoadScene("PlayerSwap2");
		wasLoadingRendered = false;
		loadingHumiditySliderClone = null;
	}
}
