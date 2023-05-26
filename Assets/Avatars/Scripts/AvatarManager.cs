using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AvatarManager
{
    private static Dictionary<int, Sprite> avatarImages = new Dictionary<int, Sprite>();
    private static int PlayerPlaying;

    public static void AddAvatarImage(int avatarId, Sprite avatarSprite)
    {
        if (!avatarImages.ContainsKey(avatarId))
        {
            avatarImages.Add(avatarId, avatarSprite);
        }
        else
        {
            Debug.LogWarning("An avatar image with the same ID already exists.");
        }
    }

    public static Sprite GetAvatarImage(int avatarId)
    {
        if (avatarImages.ContainsKey(avatarId))
        {
            return avatarImages[avatarId];
        }
        else
        {
            Debug.LogWarning("No avatar image found with ID: " + avatarId);
            return null;
        }
    }

    public static void RemoveAvatarImage(int avatarId)
    {
        if (avatarImages.ContainsKey(avatarId))
        {
            avatarImages.Remove(avatarId);
        }
        else
        {
            Debug.LogWarning("No avatar image found with ID: " + avatarId);
        }
    }

    public static void ClearAvatarImages()
    {
        avatarImages.Clear();
    }

    public static Dictionary<int, Sprite> GetChosenAvatars()
    {
        return avatarImages;
    }

    public static int GetNumChosenAvatars()
    {
        return avatarImages.Count;
    }
    public static int[] GetChosenAvatarIds()
{
    int[] chosenAvatarIds = new int[avatarImages.Count];
    int index = 0;
    foreach (var kvp in avatarImages)
    {
        chosenAvatarIds[index] = kvp.Key;
        index++;
    }
    return chosenAvatarIds;
}

public static void SetChosenAvatars(int[] chosenAvatarIds)
{
    ClearAvatarImages();
    foreach (int avatarId in chosenAvatarIds)
    {
        if (avatarImages.TryGetValue(avatarId, out Sprite avatarSprite))
        {
            AddAvatarImage(avatarId, avatarSprite);
        }
    }
}
}
