using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour
{
    public Slider lightSlider;
	public AudioSource hotDetectorSoundSource;
    public GameObject lightPaint;
	public GameObject overlay;
    public Sprite[] pictureFrames = new Sprite[5];
    public const float moveSpeed = 10.0f;
    public int paintCurrentFrame = 0;
    public const int paintCorrectFrame = 2;
    private KeyValuePair<float, float>[] lightRanges;

    void Start()
    {
        lightRanges = new KeyValuePair<float, float>[5];
        lightRanges[0] = new KeyValuePair<float, float>(20.0f, 34.9f);
        lightRanges[1] = new KeyValuePair<float, float>(35.0f, 49.9f);
        lightRanges[2] = new KeyValuePair<float, float>(50.0f, 149.9f);
        lightRanges[3] = new KeyValuePair<float, float>(150.0f, 324.9f);
        lightRanges[4] = new KeyValuePair<float, float>(325.0f, 500.0f);

		lightSlider.value = lightRanges[paintCurrentFrame].Key;
    }

    void Update()
    {   
		//If the user entered the correct range and the sound wasn't playing so far, play it
		if (hasEnteredCorrectRange() && !hotDetectorSoundSource.isPlaying)
			hotDetectorSoundSource.Play();
		else if (!hasEnteredCorrectRange())
			hotDetectorSoundSource.Stop();

		//If the user clicked the fingerprint and opened the overlay, stop the paint update
		if (overlay.activeSelf)
			return ;
			
		//Update the sliders value based on the tilting of the phone
		lightSlider.value = Mathf.Clamp(lightSlider.value + Input.acceleration.x * moveSpeed, lightSlider.minValue, lightSlider.maxValue);	
		paintCurrentFrame = getPaintFrame(lightSlider, lightRanges);
		lightPaint.GetComponent<SpriteRenderer>().sprite = pictureFrames[paintCurrentFrame];
    }

	int getPaintFrame(Slider slider, KeyValuePair<float, float>[] ranges)
	{
        for (int i = 0; i < 5; i++)
			if (between(slider.value, ranges[i].Key, ranges[i].Value))
				return i;
		return 0;
	}

	public bool hasEnteredCorrectRange()
	{
		return (paintCorrectFrame == paintCurrentFrame);
	}

	bool between(float n, float a, float b)
	{
		return (n >= a && n <= b);
	}
}
