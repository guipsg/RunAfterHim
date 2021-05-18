using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Management : MonoBehaviour {
    private static Management instance;
    [SerializeField] private AudioSource asd;
    [SerializeField] private Vector2 _checkPoint;
    [SerializeField] private bool isMenu = false;

    public Vector2 checkPoint
    {
        get { return _checkPoint; }
        set { _checkPoint = value; }
    }
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
