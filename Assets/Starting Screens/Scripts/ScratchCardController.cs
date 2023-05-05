using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScratchCardController : MonoBehaviour
{
	public SceneLoader sceneLoader;
	public GameObject maskPrefab;
	public Canvas canvas;
	public Text text;
	public List<GameObject> masks = new List<GameObject>();

	public Button button;
	public int counter = 0;
	public int maxMasks;
    void Start()
    {
		button.enabled = false;

		//Set the button normal color to dark grey
		ColorBlock colorBlock = button.colors;
		colorBlock.normalColor = new Color(0.46f, 0.46f, 0.46f, 1.0f);
		button.colors = colorBlock;

		sceneLoader.MinigameIndex = 0;
		
		if (sceneLoader.Minigames[0] == "LightStartScene")
			text.text = "Saiu o jogo da luz e da humidade!";
		else if (sceneLoader.Minigames[0] == "InsectsStartScene")
			text.text = "Saiu o jogo dos insectos!";
		else if (sceneLoader.Minigames[0] == "EarthquakeStartScene")
			text.text = "Saiu o jogo do terramoto!";
		else if (sceneLoader.Minigames[0] == "EraserStartScene")
			text.text = "Saiu o jogo do Sr.Borracha!";
    }

	void Update()
	{
		if (Input.touchCount <= 0)
			return ;
		
		//Count the number of scratches
		counter++;
		if (counter >= maxMasks)
		{
			button.enabled = true;
			ColorBlock colorBlock = button.colors;
			colorBlock.normalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			button.colors = colorBlock;
		}

		//Know there the user touch the screen
		Vector3 touchPosition = Input.GetTouch(0).position;
		touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);
		touchPosition.z = -2.0f;

		//Instantiate the mask inside the canvas
		GameObject mask = Instantiate(maskPrefab, touchPosition, Quaternion.identity, canvas.transform);
		counter++;
		masks.Add(mask);
	}
}
