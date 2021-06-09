
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
        PlayerPrefs.SetInt("Level"+level.levelID+"Points", level.points);
    }
    public static void LoadLevelProgress(LevelSelector levelSelector)
    {
        if (PlayerPrefs.HasKey("unlockedLevel"))
        {
            levelSelector.UnlockedLevels = PlayerPrefs.GetInt("unlockedLevel");
        }
    }
    public static void LoadLevelProgress(Level level)
    {
        if (PlayerPrefs.HasKey("Level" + level.levelID + "Points"))
        {
            level.points = PlayerPrefs.GetInt("Level" + level.levelID + "Points");
        }
    }

    public static void SaveAudioConfig(GameOptionsController gameOptionsController)
    {
        PlayerPrefs.SetFloat("MasterVolume", gameOptionsController.masterVolume);
        PlayerPrefs.SetFloat("SfxVolume", gameOptionsController.sfxVolume);
        PlayerPrefs.SetFloat("MusicVolume", gameOptionsController.musicVolume);
    }
    public static void LoadAudioConfig(GameOptionsController gameOptionsController)
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            gameOptionsController.masterVolume = PlayerPrefs.GetFloat("MasterVolume");
            gameOptionsController.sfxVolume = PlayerPrefs.GetFloat("SfxVolume");
            gameOptionsController.musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            SaveAudioConfig(gameOptionsController);

        }
    }

    public static void SaveLvlPontuation(int levelID, int points)
    {

        if (PlayerPrefs.HasKey("Level" + levelID + "Points"))
        {
            if (PlayerPrefs.GetInt("Level" + levelID + "Points") < points)
            {
                PlayerPrefs.SetInt("Level" + levelID + "Points", points);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Level" + levelID + "Points", points);
        }


    }
    public static void UnlockLevel(int nextLevelID)
    {
        if (PlayerPrefs.GetInt("unlockedLevel") < nextLevelID)
        {
            PlayerPrefs.SetInt("unlockedLevel", nextLevelID);
        }
    }
}
