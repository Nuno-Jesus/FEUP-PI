using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayAvatarsWithHats : MonoBehaviour
{
    public Image hatImage;
    private static List<Sprite> avatarsWithHats;
    public Button switchImages;

    // Start is called before the first frame update
    void Start()
    {
        avatarsWithHats = FinalAvatarManager.GetFinalAvatarImages();
        DisplayNewAvatarsWithIds();
		switchImages.onClick.AddListener(() => CycleToNextAvatar());
    }

    public void DisplayNewAvatarsWithIds()
    {
        if (avatarsWithHats != null && avatarsWithHats.Count > 0)
        {
            int index = 0;
            hatImage.sprite = avatarsWithHats[index];
			//Set the image size to double the size of the original image
			hatImage.rectTransform.sizeDelta = new Vector2(avatarsWithHats[index].rect.width * 3, avatarsWithHats[index].rect.height * 3);
            // hatImage.SetNativeSize(); 
            // Example: Cycle through the avatars with a button click
		}

        // Debug log the names of sprites in the list
        foreach (Sprite sprite in avatarsWithHats)
            Debug.Log("Avatar Name: " + sprite.name);
    }

    // Optional: Implement logic to cycle through the avatars with a button click
    private void CycleToNextAvatar()
    {
        int currentIndex = avatarsWithHats.IndexOf(hatImage.sprite);
        int nextIndex = (currentIndex + 1) % avatarsWithHats.Count;
        
		hatImage.sprite = avatarsWithHats[nextIndex];
		//Set the image size to double the size of the original image
		hatImage.rectTransform.sizeDelta = new Vector2(avatarsWithHats[nextIndex].rect.width * 3, avatarsWithHats[nextIndex].rect.height * 3);
    }
}
