using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> levels;

    private void Update()
    {
        foreach (Level lvl in levels)
        {
            lvl.levelID = levels.IndexOf(lvl);
        }
    }
}
