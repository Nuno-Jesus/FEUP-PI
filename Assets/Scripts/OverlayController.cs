using System.Collections;
using System.Collections.Generic;
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

    public void togglePanel()
	{
		overlay.SetActive(true);
		loadingClone = Instantiate(loading, canvas.transform);
	}

	public void Update()
	{
		if (!overlay.activeSelf)
			return;
		if (loadingClone.value < 3.0f)
			return ;
		if (lightSlider.GetComponent<LightController>().hasEnteredCorrectRange())
			SceneManager.LoadScene("PlayerSwap1");
		overlay.SetActive(false);
	}
}
