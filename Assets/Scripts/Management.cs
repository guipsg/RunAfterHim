using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Management : MonoBehaviour {
    private static Management instance;
    public AudioSource asd;
    public Vector2 checkPoint;
    public bool isMenu = false;
	// Use this for initialization
	void Awake () {

            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);

            }
            else
            {
                Destroy(gameObject);
            }


    }
    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuScene"))
        {
            asd.enabled = false;
            isMenu = true;

        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("FinalScene"))
        {
            asd.enabled = false;
            isMenu = true;

        }
        if (isMenu)
        {
            Destroy(gameObject);
        }
    }



}
