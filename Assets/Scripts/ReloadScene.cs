using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
			StartCoroutine(Restart ());
        }

    }
		
	public IEnumerator Restart(){
		yield return new WaitForSeconds(.3f);
		float fadeTime = GameObject.Find("Fade").GetComponent<FadeScript>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
