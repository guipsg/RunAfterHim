using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonPause : MonoBehaviour {

	[SerializeField] private bool paused;
    [SerializeField] private GameObject pausePanel;
    void Start()
	{
		paused = false;

	}

    public void PauseGame()
    {
        paused = true;
        pausePanel.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0;
    }

    public void ReturnGame()
    {
        paused = false;
        pausePanel.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1;
    }

}