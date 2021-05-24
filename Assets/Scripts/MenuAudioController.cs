using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioController : MonoBehaviour
{
    public GameOptionsController gameOptionsController;
    [SerializeField] private AudioClip hover, click,cancel,special;
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private float hoverVolume,clickVolume,cancelVolume,specialVolume;


    public void AudioPlay(AudioClip audio, float volume)
    {
        sfxAudioSource.PlayOneShot(audio, volume);
    }
    public void Update()
    {
        if (gameOptionsController == null)
        {
            gameOptionsController = FindObjectOfType<GameOptionsController>();
        }
        musicAudioSource.volume = gameOptionsController.musicVolume * gameOptionsController.masterVolume;
    }
    public void HoverPlay()
    {
        sfxAudioSource.ignoreListenerPause = true;
        sfxAudioSource.PlayOneShot(hover, (hoverVolume * gameOptionsController.sfxVolume) * gameOptionsController.masterVolume);
    }

    public void ClickPlay()
    {
        sfxAudioSource.ignoreListenerPause = true;
        sfxAudioSource.PlayOneShot(click, (clickVolume * gameOptionsController.sfxVolume) * gameOptionsController.masterVolume);
    }

    public void CancelPlay()
    {
        sfxAudioSource.ignoreListenerPause = true;
        sfxAudioSource.PlayOneShot(cancel, (cancelVolume * gameOptionsController.sfxVolume) * gameOptionsController.masterVolume);
    }

    public void SpecialPlay()
    {
        sfxAudioSource.ignoreListenerPause = true;
        sfxAudioSource.PlayOneShot(special, (specialVolume * gameOptionsController.sfxVolume) * gameOptionsController.masterVolume);
    }
}
