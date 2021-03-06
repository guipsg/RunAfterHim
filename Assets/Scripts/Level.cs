using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int levelID;
    public string levelName;
    public Image[] stars;
    public Color noColor;
    public Color withColor;
    public int points;
    public Button lvlButton;
    [SerializeField] private int[] pointLimit;

    private void Awake()
    {
        PlayerPrefsSystem.LoadLevelProgress(this);
        for (int i = 0; i < stars.Length; i++)
        {
            if (points >= pointLimit[i])
            {
                stars[i].color = withColor;
            }
            if (points < pointLimit[i])
            {
                stars[i].color = noColor;
            }
        }
    }

    
}
