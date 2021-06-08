using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private LevelManager lvlManager;
    [SerializeField] private Animator[] worldAnim;
    public int UnlockedLevels;
    [SerializeField] private List<Button> UnlockableButons;
    private void Start()
    {
        lvlManager = FindObjectOfType<LevelManager>();
        PlayerPrefsSystem.LoadLevelProgress(this);
        foreach (Level lvl in lvlManager.levels)
        {
            UnlockableButons.Add(lvl.lvlButton);
            foreach (Button button in UnlockableButons)
            {
                if (UnlockableButons.IndexOf(button) > UnlockedLevels)
                {
                    button.interactable = false;
                }
                else if (UnlockableButons.IndexOf(button) <= UnlockedLevels)
                {
                    button.interactable = true;
                }
            }
        }
    }
    private void Update()
    {
        
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
