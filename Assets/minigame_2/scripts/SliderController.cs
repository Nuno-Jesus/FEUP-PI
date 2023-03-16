using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderController : MonoBehaviour
{
    public Slider slider;
    public Sprite[] pictureFrames = new Sprite[5];
    public GameObject picture;
    public float moveSpeed = 10.0f;
    private KeyValuePair<float, float>[] ranges;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.minValue = 20.0f;
        slider.maxValue = 500.0f;
        slider.value = (slider.minValue - slider.maxValue)/2;

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
        slider.value = Mathf.Clamp(slider.value + Input.acceleration.x * moveSpeed, slider.minValue, slider.maxValue);
        for (int i = 0; i < 5; i++)
        {
            if (slider.value >= ranges[i].Key && slider.value <= ranges[i].Value)
            {
                picture.GetComponent<SpriteRenderer>().sprite = pictureFrames[i];
                break;                
            }
        }
    }
}
