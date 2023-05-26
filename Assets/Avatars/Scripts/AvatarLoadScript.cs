using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarLoadScript : MonoBehaviour
{
	public Image image;
    // Start is called before the first frame update
    void Start()
    {
		image = GameObject.Find("Avatar Image").GetComponent<Image>();
        image.sprite = FinalAvatarManager.GetNextAvatarImage();
		//Increase
		// image.rectTransform.sizeDelta = new Vector2(image.sprite.rect.width, image.sprite.rect.height * 1.33f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
