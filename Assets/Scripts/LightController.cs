using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour
{
    public Slider lightSlider;
	public Slider loadingSlider;
	private Slider loadingSliderClone;
	public AudioSource hotDetectorSoundSource;
	public AudioSource correctRangeSoundSource;
	public Button fingerprint;
    public GameObject lightPaint;
	public Canvas canvas;
    public Sprite[] pictureFrames = new Sprite[5];
	public bool isFingerprintClicked = false;
	public bool wasLoadingRendered = false;
	public bool enteredCorrectRange = false;
    public float moveSpeed = 10.0f;
    public int lightCurrentFrame = 0;
    public int lightCorrectFrame = 2;
    private KeyValuePair<float, float>[] lightRanges;

    void Start()
    {
        lightRanges = new KeyValuePair<float, float>[5];
        lightRanges[0] = new KeyValuePair<float, float>(20.0f, 34.9f);
        lightRanges[1] = new KeyValuePair<float, float>(35.0f, 49.9f);
        lightRanges[2] = new KeyValuePair<float, float>(50.0f, 149.9f);
        lightRanges[3] = new KeyValuePair<float, float>(150.0f, 324.9f);
        lightRanges[4] = new KeyValuePair<float, float>(325.0f, 500.0f);

		lightSlider.value = lightRanges[lightCurrentFrame].Key;
		fingerprint.onClick.AddListener(onFingerprintClick);
    }

    void Update()
    {   if (hasEnteredCorrectRange() && !hotDetectorSoundSource.isPlaying)
			hotDetectorSoundSource.Play();
		else if (!hasEnteredCorrectRange())
			hotDetectorSoundSource.Stop();

		if (isFingerprintClicked)
			checkSuccess();
		else
			lightSlider.value = Mathf.Clamp(lightSlider.value + Input.acceleration.x * moveSpeed, lightSlider.minValue, lightSlider.maxValue);	

		for (int i = 0; i < 5; i++)
		{
			if (between(lightSlider.value, lightRanges[i].Key, lightRanges[i].Value))
			{
				lightCurrentFrame = i;
				lightPaint.GetComponent<SpriteRenderer>().sprite = pictureFrames[i];
				break;                
			}
		}
    }

	void checkSuccess()
	{
		if (!wasLoadingRendered)
		{
			loadingSliderClone = Instantiate(loadingSlider, canvas.transform);
			wasLoadingRendered = true;
		}
		if (loadingSliderClone.value < 3.0f)
			return ;
		if (hasEnteredCorrectRange())
		{	
			hotDetectorSoundSource.Play();
			SceneManager.LoadScene("HumidityIntro");
		}
		isFingerprintClicked = false;
		wasLoadingRendered = false;
	}

	bool hasEnteredCorrectRange()
	{
		return (lightCorrectFrame == lightCurrentFrame);
	}

	bool between(float n, float a, float b)
	{
		return (n >= a && n <= b);
	}

	void onFingerprintClick()
	{
		isFingerprintClicked = !isFingerprintClicked;
	}
}
