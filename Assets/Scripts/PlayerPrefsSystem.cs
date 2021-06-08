
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
        PlayerPrefs.SetInt("unlockedLevel",level.levelID);

    }
    public static void LoadLevelProgress(LevelSelector levelSelector)
    {
        if (PlayerPrefs.HasKey("unlockedLevel"))
        {
            levelSelector.UnlockedLevels = PlayerPrefs.GetInt("unlockedLevel");
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
    }
}
