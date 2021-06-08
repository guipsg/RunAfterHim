using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Management : MonoBehaviour {
    private static Management instance;
    public MenuScript menuScript;
    public GameOptionsController gameOptionsController;
    public LevelManager levelManager;
    [SerializeField] private AudioSource asd;
    [SerializeField] private Vector2 _checkPoint;
    
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

        menuScript = GetComponentInChildren<MenuScript>();
        gameOptionsController = GetComponentInChildren<GameOptionsController>();
        levelManager = GetComponentInChildren<LevelManager>();

    }
    



}
