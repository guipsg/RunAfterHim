using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private LevelManager lvlManager;
    [SerializeField] private Animator[] worldAnim;
    public int UnlockedLevels;
    
    private void Start()
    {
        lvlManager = FindObjectOfType<LevelManager>();
        PlayerPrefsSystem.LoadLevelProgress(this);
        if (UnlockedLevels < 3)
        {
            worldAnim[0].gameObject.SetActive(true);
        }
        if (UnlockedLevels >= 3 && UnlockedLevels < 6)
        {
            worldAnim[1].gameObject.SetActive(true);
        }
        if (UnlockedLevels >= 6 && UnlockedLevels < 9)
        {
            worldAnim[2].gameObject.SetActive(true);
        }
        if (UnlockedLevels >= 10 && UnlockedLevels < 12)
        {
            worldAnim[3].gameObject.SetActive(true);
        }
    }

    public void NextWorld(int worldID)
    {
        StartCoroutine(NextWorldDeactivate(worldAnim[worldID].gameObject, 0.5f));
        worldAnim[worldID].Play("EndLeft");
        worldAnim[worldID + 1].gameObject.SetActive(true);
        worldAnim[worldID + 1].Play("BeginRight");
    }

    public void PreviousWorld(int worldID)
    {
        StartCoroutine(NextWorldDeactivate(worldAnim[worldID].gameObject, 0.5f));
        worldAnim[worldID].Play("EndRight");
        worldAnim[worldID - 1].gameObject.SetActive(true);
        worldAnim[worldID - 1].Play("BeginLeft");
    }

    IEnumerator NextWorldDeactivate(GameObject world,float sec)
    {
        yield return new WaitForSeconds(sec);
        world.SetActive(false);
    }

    public void UnlockNextButton(int nextLevel)
    {
        if (UnlockedLevels < nextLevel)
        {
            UnlockedLevels = nextLevel;
        }
        PlayerPrefsSystem.SaveLevelProgress(this);
    }
}
