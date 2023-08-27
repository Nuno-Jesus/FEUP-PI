using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HumidityOverlayController : MonoBehaviour
{
	public Canvas canvas;
	public GameObject overlay;
	public Slider humidityLoading;
	private Slider humidityLoadingClone = null;
	private bool wasLoadingRendered = false;
	public int lives;

	public void onConfirmClick()
	{
		initPanel();
	}

	public void Start()
	{
		lives = 2;
	}

	public void Update()
	{
		// If the confirm button wasnt pressed return
		if (!overlay.activeSelf)
			return ;

		// If this is the first time rendering the loader
		if (!wasLoadingRendered)
		{
			// Else display the loading slider
			humidityLoadingClone = Instantiate(humidityLoading, overlay.transform);
			wasLoadingRendered = true;
		}

		// Wait maxTime seconds for validation
		if (humidityLoadingClone)
			if (humidityLoadingClone.value < humidityLoadingClone.GetComponent<LoadingController>().maxTime)
				return ;
		
		// If the user locked the input in the right range, load next screen
		if (canvas.GetComponent<HumidityController>().hasEnteredTwoCorrectRanges())
			SceneManager.LoadScene("MinigameSwap1");
		else
			lives--;

		if (lives <= 0)
			SceneManager.LoadScene("GameOverScene");
		
		//Otherwise, untoggle the overlay and reset variables
		resetPanel();
	}

	void initPanel()
	{
		overlay.SetActive(true);
	}

	void resetPanel()
	{
		humidityLoadingClone = null;
		wasLoadingRendered = false;
		overlay.SetActive(false);
	}
}
