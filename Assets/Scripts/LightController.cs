using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightController : MonoBehaviour
{
    public Slider slider;
    public Sprite[] pictureFrames = new Sprite[5];
    public GameObject picture;
    public float moveSpeed = 10.0f;
    private KeyValuePair<float, float>[] ranges;
    public int correctRange = 1;
    public int currentRange = 3;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();

        ranges = new KeyValuePair<float, float>[5];
        ranges[0] = new KeyValuePair<float, float>(20.0f, 34.9f);
        ranges[1] = new KeyValuePair<float, float>(35.0f, 49.9f);
        ranges[2] = new KeyValuePair<float, float>(50.0f, 149.9f);
        ranges[3] = new KeyValuePair<float, float>(150.0f, 324.9f);
        ranges[4] = new KeyValuePair<float, float>(325.0f, 500.0f);
    }

    void Update()
    {   
        // If the users are touching the screen to lock the result, don't move the slider
        if (Input.touchCount != 0)
            return ;

        //The sliders value will adjust according to the mobile device rotation on the x axis
        slider.value = Mathf.Clamp(slider.value + Input.acceleration.x * moveSpeed, slider.minValue, slider.maxValue);
        for (int i = 0; i < 5; i++)
        {
            if (slider.value >= ranges[i].Key && slider.value <= ranges[i].Value)
            {
                currentRange = i;
                picture.GetComponent<SpriteRenderer>().sprite = pictureFrames[i];
                break;                
            }
        }
    }
}
