using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAudioController : MonoBehaviour
{
    [Range(0f,1f)]
    public float masterVolume;
    [Range(0f, 1f)]
    public float musicVolume;
    [Range(0f, 1f)]
    public float sfxVolume;

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
}
