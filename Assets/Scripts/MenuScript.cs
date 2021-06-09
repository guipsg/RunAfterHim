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
        if (PlayerPrefs.GetInt("unlockedLevel") < 1)
        {
            StartCoroutine(ChangeLevel("StartCutscene"));
        }
        else
        {
            StartCoroutine(ChangeLevel("LevelSelect"));
        }
    }
	public void ChangeScene(string sceneName) {

		StartCoroutine (ChangeLevel (sceneName));
	}
    public IEnumerator ChangeLevel(string sceneName)
    {
        float fadeTime = GameObject.Find("Fade").GetComponent<FadeScript>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneName);
    }
    public void EndGame()
    {
        StartCoroutine(QuitCoroutine());
    }
    IEnumerator QuitCoroutine()
    {
        float fadeTime = GameObject.Find("Fade").GetComponent<FadeScript>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.Quit();
    }
    public void RestartLevel()
    {
        StartCoroutine(Restart());

    }
	public IEnumerator Restart()
    {
        yield return new WaitForSeconds(.3f);
        float fadeTime = GameObject.Find("Fade").GetComponent<FadeScript>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
