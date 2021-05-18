using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    [SerializeField] private Animator an1;
    [SerializeField] private Animator an2;
    [SerializeField] private string nextLevel;
    public void StartAnim(){
        an1.SetTrigger("Incoming");
    }
    public void Go(){
        an2.SetBool("Running", true);
        an2.SetBool("Grounded", true);
    }
    public void PlayGame() {

        SceneManager.LoadScene(nextLevel);
    }
	public void ChangeScene() {

		StartCoroutine (ChangeLevel ());
	}
    public IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(1f);
        float fadeTime = GameObject.Find("Fade").GetComponent<FadeScript>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime + 1f);
        SceneManager.LoadScene(nextLevel);
    }
    public void Idle()
    {
        an2.SetBool("Running", false);
        an2.SetBool("Grounded", true);
    }
    public void Jump()
    {
        an2.SetBool("Grounded", false);
        an2.SetTrigger("Jumped");
    }
    public void Touch()
    {
        an1.SetTrigger("Touch");
    }
    public void TouchNo()
    {
        an1.SetTrigger("no");
    }
}
