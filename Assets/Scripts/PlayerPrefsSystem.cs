
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSystem : MonoBehaviour
{
    public static void SaveLevelProgress(LevelSelector levelSelector)
    {
        PlayerPrefs.SetInt("unlockedLevel",levelSelector.UnlockedLevels);
    }
    public static void SaveLevelProgress(Level level)
    {
        PlayerPrefs.SetInt("unlockedLevel", level.levelID);
    }
    public static void LoadLevelProgress(LevelSelector levelSelector)
    {
        if (PlayerPrefs.HasKey("unlockedLevel"))
        {
            levelSelector.UnlockedLevels = PlayerPrefs.GetInt("unlockedLevel");
        }
    }
}
