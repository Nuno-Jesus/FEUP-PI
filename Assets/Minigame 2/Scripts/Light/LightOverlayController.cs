using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LightOverlayController : MonoBehaviour
{
	public Canvas canvas;
	public GameObject overlay;
	public Slider loading;
	private Slider loadingClone;
	public Slider lightSlider;
	public GameObject container;
	public Button buttonPrefab;
	public Button[] fingerprints;
	private bool[] wasFingerprintClicked = new bool[6];	
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
		fingerprints = new Button[FinalAvatarManager.GetFinalAvatarImages().Count];
		GameObject button;

		button = Instantiate(buttonPrefab.gameObject, container.transform);
		fingerprints[0] = button.GetComponent<Button>();
		fingerprints[0].onClick.AddListener(onFirstFingerprintClick);
		
		button = Instantiate(buttonPrefab.gameObject, container.transform);
		fingerprints[1] = button.GetComponent<Button>();
		fingerprints[1].onClick.AddListener(onSecondFingerprintClick);
		
		if (FinalAvatarManager.GetFinalAvatarImages().Count < 3)
			return ;

		button = Instantiate(buttonPrefab.gameObject, container.transform);
		fingerprints[2] = button.GetComponent<Button>();
		fingerprints[2].onClick.AddListener(onThirdFingerprintClick);

		if (FinalAvatarManager.GetFinalAvatarImages().Count < 4)
			return ;
			
		button = Instantiate(buttonPrefab.gameObject, container.transform);
		fingerprints[3] = button.GetComponent<Button>();
		fingerprints[3].onClick.AddListener(onFourthFingerprintClick);
		
		if (FinalAvatarManager.GetFinalAvatarImages().Count < 5)
			return ;
			
		button = Instantiate(buttonPrefab.gameObject, container.transform);
		fingerprints[4] = button.GetComponent<Button>();
		fingerprints[4].onClick.AddListener(onFifthFingerprintClick);
		
		if (FinalAvatarManager.GetFinalAvatarImages().Count < 6)
			return ;
			
		button = Instantiate(buttonPrefab.gameObject, container.transform);
		fingerprints[5] = button.GetComponent<Button>();
		fingerprints[5].onClick.AddListener(onSixthFingerprintClick);
	}

	public void Update()
	{
		// This script should only run if the primary fingerprint was toggled
		if (!overlay.activeSelf)
			return;
		
		// If one of the buttons wasn't clicked, abort
		for (int i = 0; i < FinalAvatarManager.GetFinalAvatarImages().Count; i++)
			if (!wasFingerprintClicked[i])
				return ;
		
		// If this is the first time rendering the loader
		if (!wasLoadingRendered)
		{
			// Else display the loading slider
			loadingClone = Instantiate(loading, canvas.transform);
			wasLoadingRendered = true;
			
			// Disable the fingerprint buttons
			for (int i = 0; i < FinalAvatarManager.GetFinalAvatarImages().Count; i++)
				fingerprints[i].enabled = false;
			gameObject.GetComponent<Button>().enabled = false;
		}

		// Wait maxTime seconds for validation
		if (loadingClone)
			if (loadingClone.value < loadingClone.GetComponent<LoadingController>().maxTime)
				return ;
		
		// If the user locked the input in the right range, load next screen
		if (lightSlider.GetComponent<LightController>().hasEnteredCorrectRange())
			SceneManager.LoadScene("LightHumiditySwap");
		
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
	void onFifthFingerprintClick()
	{
		wasFingerprintClicked[4] = !wasFingerprintClicked[4];
		if (wasFingerprintClicked[4])
			fingerprints[4].GetComponent<Image>().sprite = activeSprite;
		else
			fingerprints[4].GetComponent<Image>().sprite = inactiveSprite;
	}
	void onSixthFingerprintClick()
	{
		wasFingerprintClicked[5] = !wasFingerprintClicked[5];
		if (wasFingerprintClicked[5])
			fingerprints[5].GetComponent<Image>().sprite = activeSprite;
		else
			fingerprints[5].GetComponent<Image>().sprite = inactiveSprite;
	}

	void initPanel()
	{
		gameObject.GetComponentInChildren<Text>().text = "CANCELAR";
		gameObject.GetComponent<Button>().enabled = true;
		lightSlider.enabled = false;
		Array.Fill(wasFingerprintClicked, false);
		for (int i = 0; i < FinalAvatarManager.GetFinalAvatarImages().Count; i++)
		{
			fingerprints[i].enabled = true;
			fingerprints[i].GetComponent<Image>().sprite = inactiveSprite;
		}
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
