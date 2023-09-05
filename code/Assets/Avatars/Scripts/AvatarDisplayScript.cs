using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarDisplayScript : MonoBehaviour
{
	public Image avatarImage;
	public Button switchButton;

	private Dictionary<int, int> chosenAvatars;
	private Dictionary<int, Sprite> avatarImages;
	private List<int> avatarIds;
	public int currentIndex = 0;
	// Hat sprites
	public Sprite caoChapeuAlto;
	public Sprite caoChapeuMetal;
	public Sprite caoChapeuPano;
	public Sprite caoChapeu2;

	public Sprite cortesaoChapeuAlto;
	public Sprite cortesaoChapeuMetal;
	public Sprite cortesaoChapeuPano;
	public Sprite cortesaoChapeu2;

	public Sprite gatoChapeuAlto;
	public Sprite gatoChapeuMetal;
	public Sprite gatoChapeuPano;
	public Sprite gatoChapeu2;

	public Sprite princesaChapeuAlto;
	public Sprite princesaChapeuMetal;
	public Sprite princesaChapeuPano;
	public Sprite princesaChapeu2;

	public Sprite senhoraChapeuAlto;
	public Sprite senhoraChapeuMetal;
	public Sprite senhoraChapeuPano;
	public Sprite senhoraChapeu2;

	public Sprite soldadoChapeuAlto;
	public Sprite soldadoChapeuMetal;
	public Sprite soldadoChapeuPano;
	public Sprite soldadoChapeu2;

	//public Image avatarImage; // Reference to the avatar image
	public Button ChapeuAlto_Button;
	public Button ChapeuMetal_Button;
	public Button ChapeuPano_Button;
	public Button Chapeu2_Button;
	public Button ConfirmHat_Button;
	public Button advanceButton;

	private Dictionary<int, Dictionary<string, Sprite>> avatarHatImages; // Dictionary to store the hat images
	private int currentAvatarId; // Current avatar ID
	private int counter; //counter to know when to active the advance button
	private string currentHatName;
	private void Start()
	{
		//avatarCustomization = FindObjectOfType<AvatarCustomization>();
		chosenAvatars = AvatarScript.ChosenAvatars;
		avatarImages = AvatarScript.AvatarImages;
		avatarIds = new List<int>();

		// Populate avatarIds list with chosen avatar IDs in the order they were chosen
		foreach (int avatarId in chosenAvatars.Values)
		{
			if (avatarImages.ContainsKey(avatarId))
			{
				avatarIds.Add(avatarId);
			}
			else
			{
			}
		}

		currentIndex = 0; // Start at index 0

		InitializeAvatarHatImages();
		AttachButtonListeners();

		DisplayCurrentAvatar();
	}

	public void SwitchToNextAvatar()
	{
		if (chosenAvatars.Count <= 1)
			return;

		currentIndex = (currentIndex + 1) % chosenAvatars.Count;
		int avatarId = avatarIds[currentIndex];

		DisplayCurrentAvatar();
	}

	public void DisplayCurrentAvatar()
	{
		int avatarId = avatarIds[currentIndex];

		if (avatarImages.TryGetValue(avatarId, out Sprite avatarSprite))
			avatarImage.sprite = avatarSprite;

		// Hide the ConfirmHat button
		ConfirmHat_Button.gameObject.SetActive(false);

		if (counter == avatarIds.Count)
		{
			advanceButton.gameObject.SetActive(true);
		}
		// Show or hide the advance button based on the confirmation status

	}

	private void InitializeAvatarHatImages()
	{
		avatarHatImages = new Dictionary<int, Dictionary<string, Sprite>>();

		// Avatar 1
		Dictionary<string, Sprite> avatar1HatImages = new Dictionary<string, Sprite>
		{
			{ "ChapeuAlto", caoChapeuAlto },
			{ "ChapeuMetal", caoChapeuMetal },
			{ "ChapeuPano", caoChapeuPano },
			{ "Chapeu2", caoChapeu2 }
		};
		avatarHatImages.Add(1, avatar1HatImages);

		// Avatar 2
		Dictionary<string, Sprite> avatar2HatImages = new Dictionary<string, Sprite>
		{
			{ "ChapeuAlto", cortesaoChapeuAlto },
			{ "ChapeuMetal", cortesaoChapeuMetal },
			{ "ChapeuPano", cortesaoChapeuPano },
			{ "Chapeu2", cortesaoChapeu2 }
		};
		avatarHatImages.Add(2, avatar2HatImages);

		// Avatar 3
		Dictionary<string, Sprite> avatar3HatImages = new Dictionary<string, Sprite>
		{
			{ "ChapeuAlto", gatoChapeuAlto },
			{ "ChapeuMetal", gatoChapeuMetal },
			{ "ChapeuPano", gatoChapeuPano },
			{ "Chapeu2", gatoChapeu2 }
		};
		avatarHatImages.Add(3, avatar3HatImages);

		// Avatar 4
		Dictionary<string, Sprite> avatar4HatImages = new Dictionary<string, Sprite>
		{
			{ "ChapeuAlto", princesaChapeuAlto },
			{ "ChapeuMetal", princesaChapeuMetal },
			{ "ChapeuPano", princesaChapeuPano },
			{ "Chapeu2", princesaChapeu2 }
		};
		avatarHatImages.Add(4, avatar4HatImages);

		// Avatar 5
		Dictionary<string, Sprite> avatar5HatImages = new Dictionary<string, Sprite>
		{
			{ "ChapeuAlto", senhoraChapeuAlto },
			{ "ChapeuMetal", senhoraChapeuMetal },
			{ "ChapeuPano", senhoraChapeuPano },
			{ "Chapeu2", senhoraChapeu2 }
		};
		avatarHatImages.Add(5, avatar5HatImages);

		// Avatar 6
		Dictionary<string, Sprite> avatar6HatImages = new Dictionary<string, Sprite>
		{
			{ "ChapeuAlto", soldadoChapeuAlto },
			{ "ChapeuMetal", soldadoChapeuMetal },
			{ "ChapeuPano", soldadoChapeuPano },
			{ "Chapeu2", soldadoChapeu2 }
		};
		avatarHatImages.Add(6, avatar6HatImages);

	}

	private void AttachButtonListeners()
	{
		// Attach button click listeners to the hat buttons
		ChapeuAlto_Button.onClick.AddListener(() => SetHat("ChapeuAlto"));
		ChapeuMetal_Button.onClick.AddListener(() => SetHat("ChapeuMetal"));
		ChapeuPano_Button.onClick.AddListener(() => SetHat("ChapeuPano"));
		Chapeu2_Button.onClick.AddListener(() => SetHat("Chapeu2"));
		advanceButton.onClick.AddListener(() => SwitchScene());
		ConfirmHat_Button.onClick.AddListener(() => ConfirmHat(currentHatName));
	}

	private void SwitchScene()
	{
		SceneManager.LoadScene("CustomizeScene");
	}

	public void SetHat(string hatName)
	{
		// Update the current avatar ID based on the current index in avatarIds
		currentAvatarId = avatarIds[currentIndex];
		currentHatName = hatName;

		// Update the avatar image with the selected hat and current avatar ID
		UpdateAvatarImage(hatName, currentAvatarId);

		// Show the ConfirmHat button
		ConfirmHat_Button.gameObject.SetActive(true);
	}

	private void ConfirmHat(string hatName)
	{
		// Store the selected hat image
		Sprite selectedHatSprite = GetHatSprite(hatName, currentAvatarId);

		if (selectedHatSprite == null)
			return ;
		// Update the avatar image with the selected hat
		avatarImages[currentAvatarId] = selectedHatSprite;

		// Add the selected hat image to the FinalAvatarManager
		FinalAvatarManager.AddAvatarImage(selectedHatSprite);

		counter++;
		// Advance to the next avatar
		SwitchToNextAvatar();
	}



	private void UpdateAvatarImage(string selectedHat, int avatarId)
	{
		Dictionary<string, Sprite> currentAvatarHatImages;
		Sprite hatSprite;

		if (avatarHatImages.TryGetValue(avatarId, out currentAvatarHatImages))
			if (currentAvatarHatImages.TryGetValue(selectedHat, out hatSprite))
				avatarImage.sprite = hatSprite;
	}

	private Sprite GetHatSprite(string hatName, int avatarId)
	{
		if (avatarHatImages.TryGetValue(avatarId, out Dictionary<string, Sprite> currentAvatarHatImages))
			if (currentAvatarHatImages.TryGetValue(hatName, out Sprite hatSprite))
				return hatSprite;

		return null;
	}
}
