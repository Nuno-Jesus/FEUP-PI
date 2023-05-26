using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class AvatarScript : MonoBehaviour
{
    public Button Button_DisplayAvatars;
    public Button[] avatarButtons;
    public Button Button_ResetSelection;
    public Button HadHatButton;

    private List<Button> avatarButtonsInitialState = new List<Button>();

    public int NumOfPlayers;
    public int AvatarId;
    public bool[] AvatarChosen = new bool[6];

    public static Dictionary<int, Sprite> AvatarImages = new Dictionary<int, Sprite>();
    public static Dictionary<int, int> ChosenAvatars = new Dictionary<int, int>();

    public Sprite imageCao;
    public Sprite imageCortesao;
    public Sprite imageGato;
    public Sprite imagePrincesa;
    public Sprite imageSenhora;
    public Sprite imageSoldado1;

    public GameObject hatMenuContainer;
    public GameObject AvatarContainer;

    private void Start()
    {
        // Reset the PlayerPrefs key for chosen avatars at the start of the scene
        PlayerPrefs.DeleteKey("ChosenAvatars");
        // Clear the chosen avatars at the start of the scene
        ChosenAvatars.Clear();
        // Populate the dictionary with avatar ID-image pairs
        AvatarImages.Clear();
        AvatarImages[1] = imageCao;
        AvatarImages[2] = imageCortesao;
        AvatarImages[3] = imageGato;
        AvatarImages[4] = imagePrincesa;
        AvatarImages[5] = imageSenhora;
        AvatarImages[6] = imageSoldado1;
        // Store the initial state of the avatar buttons
        foreach (Button button in avatarButtons)
        {
            avatarButtonsInitialState.Add(button);
        }
    }

    public void ChooseAvatar(GameObject button)
{
    NumOfPlayers++;
    Match match = Regex.Match(button.name, @"\d+");
    if (match.Success)
    {
        AvatarId = int.Parse(match.Value);
    }
    // Disable the button so it cannot be chosen again
    button.GetComponent<Button>().interactable = false;
    // Store the chosen avatar in the dictionary
    ChosenAvatars.Add(NumOfPlayers, AvatarId);
    // Check if enough players have chosen avatars
    if (NumOfPlayers >= 2)
    {
        Button_DisplayAvatars.gameObject.SetActive(true);
        Button_ResetSelection.gameObject.SetActive(true);
    }
}


    public void DisplayChosenAvatars()
    {
        // Clear the existing objects in the scene
        GameObject[] avatarImages = GameObject.FindGameObjectsWithTag("Avatar");
        foreach (GameObject avatarImage in avatarImages)
        {
            Destroy(avatarImage);
        }

        // Calculate the number of rows and columns based on the number of chosen avatars
        int numChosenAvatars = ChosenAvatars.Count;
        int numRows = Mathf.CeilToInt(Mathf.Sqrt(numChosenAvatars));
        int numColumns = Mathf.CeilToInt((float)numChosenAvatars / numRows);

        // Calculate the spacing between avatars
        float spacingX = 450f;
        float spacingY = 600f;

        // Calculate the starting position of the avatars
        float startX = -(numColumns - 1) * spacingX * 0.5f;
        float startY = (numRows - 1) * spacingY * 0.5f - 0f; // Adjust the offset value here

        int avatarIndex = 0;

        // Display the chosen avatar images
        foreach (var kvp in ChosenAvatars)
        {
            int playerId = kvp.Key;
            int avatarId = kvp.Value;

            // Instantiate the avatar image object
            GameObject avatarImage = new GameObject("Avatar");
            avatarImage.transform.SetParent(transform);
            avatarImage.tag = "Avatar";

            // Set the sprite of the avatar image based on the chosen avatar ID
            Sprite avatarSprite;
            if (AvatarImages.TryGetValue(avatarId, out avatarSprite))
            {
                Image imageComponent = avatarImage.AddComponent<Image>();
                imageComponent.sprite = avatarSprite;
				//Set the image size to double the size of the original image
				imageComponent.rectTransform.sizeDelta = new Vector2(avatarSprite.rect.width * 1.5f, avatarSprite.rect.height * 1.3f);
				// imageComponent.SetNativeSize(); // Adjust the size of the Image component to match the new sprite size
            }

            // Calculate the position of the avatar image based on the index in the grid layout
            int row = avatarIndex / numColumns;
            int column = avatarIndex % numColumns;
            float posX = startX + column * spacingX;
            float posY = startY - row * spacingY;

            // Set the position and scale of the avatar image
            avatarImage.transform.localPosition = new Vector3(posX, posY, 0f);
            avatarImage.transform.localScale = new Vector3(1f, 1.2f, 1f); // Adjust the scale here

            avatarIndex++;
        }

        // Enable the reset button
        Button_ResetSelection.interactable = true;

        // Clean up the scene by disabling unnecessary objects
        Button_DisplayAvatars.gameObject.SetActive(false);
        Button_ResetSelection.gameObject.SetActive(false);

        // Activate the "Had Hat" button
        HadHatButton.gameObject.SetActive(true);
    }

    public void ResetSelection()
    {
        // Clear the chosen avatars dictionary
        ChosenAvatars.Clear();
        // Clear the existing objects in the scene
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Avatar"))
        {
            Destroy(obj);
        }
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Deactivate the reset button
        Button_ResetSelection.interactable = false;
    }

    public void ActivateHatMenu()
    {
        // Remove the avatar image game objects
        GameObject[] avatarImages = GameObject.FindGameObjectsWithTag("Avatar");
        foreach (GameObject avatarImage in avatarImages)
        {
            Destroy(avatarImage);
        }
        hatMenuContainer.SetActive(true);
        AvatarContainer.SetActive(true);
        HadHatButton.gameObject.SetActive(false);
    }
}
