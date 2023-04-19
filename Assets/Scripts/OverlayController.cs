using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OverlayController : MonoBehaviour
{
	public Canvas canvas;
	public GameObject overlay;
	public Slider loading;
	private Slider loadingClone;
	public Slider lightSlider;
	public Button[] fingerprints = new Button[3];
	public bool[] wasFingerprintClicked = new bool[3];
	public bool wasLoadingRendered = false; 
	public Sprite activeSprite;
	public Sprite inactiveSprite;

    public void togglePanel()
	{
		overlay.SetActive(!overlay.activeSelf);
	}

	public void Start()
	{
		fingerprints[0].onClick.AddListener(onFirstFingerprintClick);
		fingerprints[1].onClick.AddListener(onSecondFingerprintClick);
		fingerprints[2].onClick.AddListener(onThirdFingerprintClick);
	}

	public void Update()
	{
		// This script should only run if the primary fingerprint was toggled
		if (!overlay.activeSelf)
			return;
		if (!wasLoadingRendered)
		{
			// If one of the buttons wasn't clicked, abort
			if (!wasFingerprintClicked.All(x => x == true))
				return ;
		
			// Else display the loading slider
			loadingClone = Instantiate(loading, canvas.transform);
			wasLoadingRendered = true;
		}

		// Wait 3 seconds for validation
		if (loadingClone.value < 3.0f)
			return ;
		
		// If the user locked the input in the right range, load next screen
		if (lightSlider.GetComponent<LightController>().hasEnteredCorrectRange())
			SceneManager.LoadScene("PlayerSwap1");
		
		//Otherwise, untoggle the overlay and reset variables
		reset();
	}

	void onFirstFingerprintClick()
	{
		wasFingerprintClicked[0] = !wasFingerprintClicked[0];
		if (wasFingerprintClicked[0])
			fingerprints[0].GetComponent<Image>().sprite = activeSprite;
		else
			fingerprints[0].GetComponent<Image>().sprite = inactiveSprite;
	}
	void onSecondFingerprintClick()
	{
		wasFingerprintClicked[1] = !wasFingerprintClicked[1];
		if (wasFingerprintClicked[1])
			fingerprints[1].GetComponent<Image>().sprite = activeSprite;
		else
			fingerprints[1].GetComponent<Image>().sprite = inactiveSprite;
	}
	void onThirdFingerprintClick()
	{
		wasFingerprintClicked[2] = !wasFingerprintClicked[2];
		if (wasFingerprintClicked[2])
			fingerprints[2].GetComponent<Image>().sprite = activeSprite;
		else
			fingerprints[2].GetComponent<Image>().sprite = inactiveSprite;
	}

	void reset()
	{
		togglePanel();
		Array.ForEach(fingerprints, button => button.GetComponent<Image>().sprite = inactiveSprite);
		Array.Fill(wasFingerprintClicked, false);
		wasLoadingRendered = false;
		loadingClone = null;
	}
}
