using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverlayController : MonoBehaviour
{
    public bool upperLeftButtonClicked = false;
    public bool upperRightButtonClicked = false;
    public bool lowerLeftButtonClicked = false;
    public bool lowerRightButtonClicked = false;

    public Button upperLeftButton;
    public Button upperRightButton;
    public Button lowerLeftButton;
    public Button lowerRightButton;

    public int numberButtonsClicked = 0;
    // Start is called before the first frame update
    void Start()
    {
        upperLeftButton.onClick.AddListener(onUpperLeftClicked);
        upperRightButton.onClick.AddListener(onUpperRightClicked);
        lowerLeftButton.onClick.AddListener(onLowerLeftClicked);
        lowerRightButton.onClick.AddListener(onLowerRightClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (upperLeftButtonClicked && upperRightButtonClicked && lowerLeftButtonClicked && lowerRightButtonClicked)
            SceneManager.LoadScene("HumidityIntro");
    }

    void onUpperLeftClicked()
    {
        Debug.Log("Upper Left Clicked");
        upperLeftButtonClicked = !upperLeftButtonClicked;
    }

    void onUpperRightClicked()
    {
        Debug.Log("Upper Right Clicked");
        upperRightButtonClicked = !upperRightButtonClicked;
    }

    void onLowerLeftClicked()
    {
        Debug.Log("Lower Left Clicked");
        lowerLeftButtonClicked = !lowerLeftButtonClicked;
    }

    void onLowerRightClicked()
    {
        Debug.Log("Lower Right Clicked");
        lowerRightButtonClicked = !lowerRightButtonClicked;
    }
}
