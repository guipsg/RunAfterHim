using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElevadorScript : MonoBehaviour {

    public PlayerMovementPrototype player;
    public string nextLevel;
    int cont = 0;
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")){
                player.canMove = false;
                player.cont = 0;
                player.Flip();
                player.rb.velocity = new Vector2(0f, 0f);
                player.velocity = 0;
                StartCoroutine(ChangeLevel());
        }
    }

    IEnumerator ChangeLevel(){
        yield return new WaitForSeconds(.3f);
        float fadeTime = GameObject.Find("Fade").GetComponent<FadeScript>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(nextLevel);
    }
}
