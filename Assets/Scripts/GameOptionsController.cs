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

    Resolution[] resolutions;


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
    }
    public void ChangeMusicVolume(Slider slider)
    {
        musicVolume = slider.value;
    }
    public void ChangeSFXVolume(Slider slider)
    {
        sfxVolume = slider.value;
    }
    public void ChangeFullScreen(bool fullscreen)
    {
        isFullscreen = fullscreen;
        Screen.fullScreen = fullscreen;
    }

}
