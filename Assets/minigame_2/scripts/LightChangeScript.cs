using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightChangeScript : MonoBehaviour
{
    public Slider slider;
    public Sprite[] pictureFrames = new Sprite[5];
    private GameObject picture;
    private int index = 0;
    private float moveSpeed = 0.02f;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        picture = GameObject.Find("Changing Oil Paint");
    }

    void Update()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        slider.value = Mathf.Clamp(slider.value + Input.acceleration.x * moveSpeed, 0, 1);
        Debug.Log("ACCEL: " + Input.acceleration.x);
        Debug.Log("VALUE: " + slider.value);
        index = (int)(slider.value * 4);
        picture.GetComponent<SpriteRenderer>().sprite = pictureFrames[index];
    }
}
