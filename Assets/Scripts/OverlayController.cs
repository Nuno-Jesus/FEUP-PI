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
	public Button[] fingerprints = new Button[4];
	private bool[] wasFingerprintClicked = new bool[4];	
	private bool wasLoadingRendered = false; 
	public Sprite activeSprite;
	public Sprite inactiveSprite;

    public void togglePanel()
	{
		if (!overlay.activeSelf)
			initPanel();
		else
			resetPanel();
	}

	public void Start()
	{
		fingerprints[0].onClick.AddListener(onFirstFingerprintClick);
		fingerprints[1].onClick.AddListener(onSecondFingerprintClick);
		fingerprints[2].onClick.AddListener(onThirdFingerprintClick);
		fingerprints[3].onClick.AddListener(onFourthFingerprintClick);
	}

	public void Update()
	{
		// This script should only run if the primary fingerprint was toggled
		if (!overlay.activeSelf)
			return;
		
		// If one of the buttons wasn't clicked, abort
		if (!wasFingerprintClicked.All(x => x == true))
			return ;
		
		// If this is the first time rendering the loader
		if (!wasLoadingRendered)
		{
			// Else display the loading slider
			loadingClone = Instantiate(loading, canvas.transform);
			wasLoadingRendered = true;
			
			// Disable the fingerprint buttons
			Array.ForEach(fingerprints, button => button.enabled = false);
			gameObject.GetComponent<Button>().enabled = false;
		}

		// Wait maxTime seconds for validation
		if (loadingClone)
			if (loadingClone.value < loadingClone.GetComponent<LoadingController>().maxTime)
				return ;
		
		// If the user locked the input in the right range, load next screen
		if (lightSlider.GetComponent<LightController>().hasEnteredCorrectRange())
			SceneManager.LoadScene("PlayerSwap1");
		
		//Otherwise, untoggle the overlay and reset variables
		resetPanel();
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
	void onFourthFingerprintClick()
	{
		wasFingerprintClicked[3] = !wasFingerprintClicked[3];
		if (wasFingerprintClicked[3])
			fingerprints[3].GetComponent<Image>().sprite = activeSprite;
		else
			fingerprints[3].GetComponent<Image>().sprite = inactiveSprite;
	}

	void initPanel()
	{
		gameObject.GetComponentInChildren<Text>().text = "CANCELAR";
		gameObject.GetComponent<Button>().enabled = true;
		lightSlider.enabled = false;
		Array.Fill(wasFingerprintClicked, false);
		Array.ForEach(fingerprints, button => button.enabled = true);
		Array.ForEach(fingerprints, button => button.GetComponent<Image>().sprite = inactiveSprite);
		overlay.SetActive(true);
	}

	void resetPanel()
	{
		gameObject.GetComponentInChildren<Text>().text = "CONFIRMAR";
		gameObject.GetComponent<Button>().enabled = true;
		loadingClone = null;
		lightSlider.enabled = true;
		wasLoadingRendered = false;
		overlay.SetActive(false);
	}
}
