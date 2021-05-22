using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioController : MonoBehaviour
{
    public GameAudioController gameAudioController;
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
        if (gameAudioController == null)
        {
            gameAudioController = FindObjectOfType<GameAudioController>();
        }
        musicAudioSource.volume = gameAudioController.musicVolume * gameAudioController.masterVolume;
    }
    public void HoverPlay()
    {
        sfxAudioSource.ignoreListenerPause = true;
        sfxAudioSource.PlayOneShot(hover, (hoverVolume * gameAudioController.sfxVolume) * gameAudioController.masterVolume);
    }

    public void ClickPlay()
    {
        sfxAudioSource.ignoreListenerPause = true;
        sfxAudioSource.PlayOneShot(click, (clickVolume * gameAudioController.sfxVolume) * gameAudioController.masterVolume);
    }

    public void CancelPlay()
    {
        sfxAudioSource.ignoreListenerPause = true;
        sfxAudioSource.PlayOneShot(cancel, (cancelVolume * gameAudioController.sfxVolume) * gameAudioController.masterVolume);
    }

    public void SpecialPlay()
    {
        sfxAudioSource.ignoreListenerPause = true;
        sfxAudioSource.PlayOneShot(special, (specialVolume * gameAudioController.sfxVolume) * gameAudioController.masterVolume);
    }
}
