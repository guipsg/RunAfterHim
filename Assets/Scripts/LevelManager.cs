using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Management mg;
    static public LevelManager instance;
    public int activeLevelID;
    public int activeLevelPoints;
    public string activeLevelName;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }
        mg = GameObject.FindGameObjectWithTag("Manager").GetComponent<Management>();
    }

    public void StartLevel()
    {
        ChangeScene(activeLevelName);
    }
    public void EndLevel()
    {
        ChangeScene(activeLevelName);
    }

    public void ChangeScene(string sceneName)
    {

        StartCoroutine(ChangeLevel(sceneName));
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

}
