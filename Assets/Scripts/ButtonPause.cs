using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonPause : MonoBehaviour {

	[SerializeField] private bool paused;
	void Start()
	{
		paused = false;

	}

	public void Pause(){
        
		paused = !paused;
		

		if(paused) {
            
			Time.timeScale = 0;
		}

		else if(!paused){
			Time.timeScale = 1;
		}
	}

}