using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FinalAvatarManager
{
    private static List<Sprite> finalAvatarImages;
	private static int index;
    static FinalAvatarManager()
    {
        finalAvatarImages = new List<Sprite>();
    }

    public static void AddAvatarImage(Sprite avatarSprite)
    {
        finalAvatarImages.Add(avatarSprite);
    }

    public static List<Sprite> GetFinalAvatarImages()
    {
        return finalAvatarImages;
    }

	public static Sprite GetNextAvatarImage()
	{
		return finalAvatarImages[index++ % finalAvatarImages.Count];
	}
}
