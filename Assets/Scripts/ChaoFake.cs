using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoFake : MonoBehaviour {
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("SfxVolume") * PlayerPrefs.GetFloat("MasterVolume");
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 4f;
            
            audioSource.Play();
        }

    }

}


