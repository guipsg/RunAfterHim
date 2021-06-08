using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] private float videolenght;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitVideoToLoad());
    }

    IEnumerator WaitVideoToLoad()
    {
        yield return new WaitForSeconds(videolenght);
        StartCoroutine(ChangeLevel("StartMenu"));
    }
    public IEnumerator ChangeLevel(string sceneName)
    {
        float fadeTime = GameObject.Find("Fade").GetComponent<FadeScript>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneName);
    }
}
