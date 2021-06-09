using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOptionsController : MonoBehaviour
{
    [Range(0f, 1f)]
    public float masterVolume;
    [Range(0f, 1f)]
    public float musicVolume;
    [Range(0f, 1f)]
    public float sfxVolume;

    public bool isFullscreen;

    [SerializeField] private Dropdown resolutionsDropdown;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;


    Resolution[] resolutions;

    private void Awake()
    {
        PlayerPrefsSystem.LoadAudioConfig(this);
        masterSlider.value = masterVolume;
        sfxSlider.value = sfxVolume;
        musicSlider.value = musicVolume;
    }
    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionsDropdown.ClearOptions();
        
        List<string> options = new List<string>();
        int indexRes = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                indexRes = i;
            }

        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = indexRes;
        resolutionsDropdown.RefreshShownValue();

    }

    public void ChangeResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void ChangeDropdownResolution(bool up)
    {
        if (up)
        {
            resolutionsDropdown.value++;
            resolutionsDropdown.RefreshShownValue();
        }
        if (!up)
        {
            resolutionsDropdown.value--;
            resolutionsDropdown.RefreshShownValue();
        }
    }

    public void ChangeMasterVolume(Slider slider)
    {
        masterVolume = slider.value;
        PlayerPrefsSystem.SaveAudioConfig(this);
    }
    public void ChangeMusicVolume(Slider slider)
    {
        musicVolume = slider.value;
        PlayerPrefsSystem.SaveAudioConfig(this);
    }
    public void ChangeSFXVolume(Slider slider)
    {
        sfxVolume = slider.value;
        PlayerPrefsSystem.SaveAudioConfig(this);
    }
    public void ChangeFullScreen(bool fullscreen)
    {
        isFullscreen = fullscreen;
        Screen.fullScreen = fullscreen;
    }

}
