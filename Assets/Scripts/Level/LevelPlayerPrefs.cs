using UnityEngine;

public static class LevelPlayerPrefs
{
    private static readonly string LevelWord = "Level";
    private static readonly string StarsWord = "Stars";

    public static int GetLevelStars(int levelNumber)
    {
        string levelStarsPreferences = LevelWord + levelNumber + StarsWord;
        if (PlayerPrefs.HasKey(levelStarsPreferences))
        {
            return PlayerPrefs.GetInt(levelStarsPreferences);
        }
        return 0;
    }

    public static void SaveLevelStars(int levelNumber, int levelStars)
    {
        string levelStarsPreferences = LevelWord + levelNumber + StarsWord;
        PlayerPrefs.SetInt(levelStarsPreferences, levelStars);
    }
    
}
