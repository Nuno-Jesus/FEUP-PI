using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightChangeScript : MonoBehaviour
{
    public Slider slider;
    public Sprite[] pictureFrames = new Sprite[5];
    private GameObject picture;
    private float timer = 0;
    private float angleDegrees = 45;
    private float offset = 1;
    public float changingSpeed = 0.01f;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        picture = GameObject.Find("Changing Oil Paint");
        Debug.Log(slider.value);
    }

    void Update()
    {
        int index;
        if (timer < changingSpeed)
            timer += Time.deltaTime;
        else
        {           
            if (angleDegrees == 90)
                offset = -1;
            else if (angleDegrees == 0)
                offset = 1;       
            
            angleDegrees += offset;
            slider.value = Mathf.Pow(Mathf.Sin(angleDegrees * Mathf.PI / 180) , 2);

            index = (int)(slider.value * 4);
            picture.GetComponent<SpriteRenderer>().sprite = pictureFrames[index];
            timer = 0;
        }
        
    }
}
