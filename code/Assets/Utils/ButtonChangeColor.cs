using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;

	public void onWrongButtonClick()
	{
		ColorBlock buttonColors = button.colors;

		buttonColors.normalColor = Color.red;
		buttonColors.highlightedColor = Color.red;
		buttonColors.selectedColor = Color.red;
		buttonColors.pressedColor = Color.red;
		button.GetComponentInChildren<Text>().color = Color.white;
		button.colors = buttonColors;
	}
	public void onRightButtonClick()
	{
		ColorBlock buttonColors = button.colors;

		buttonColors.normalColor = Color.green;
		buttonColors.highlightedColor = Color.green;
		buttonColors.selectedColor = Color.green;
		buttonColors.pressedColor = Color.green;
		button.GetComponentInChildren<Text>().color = Color.white;
		button.colors = buttonColors;
	}
}
