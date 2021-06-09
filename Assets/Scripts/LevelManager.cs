using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class LevelManager : MonoBehaviour
{
    public List<Level> levels;
    public List<Button> Buttons;
    [SerializeField] private MenuScript menuScript;
    
    private void Awake()
    {
        menuScript = FindObjectOfType<MenuScript>();
        
    }
    private void Start()
    {
        foreach (Level lvl in levels)
        {
            lvl.levelID = levels.IndexOf(lvl);
            lvl.lvlButton = lvl.gameObject.GetComponent<Button>();
            Buttons.Insert(lvl.levelID, lvl.lvlButton);
            foreach (Button button in Buttons)
            {
                if (Buttons.IndexOf(button) == lvl.levelID)
                {
                button.onClick.AddListener(delegate { menuScript.ChangeScene(lvl.levelName); });
                }
            }
            if (lvl.levelID == PlayerPrefs.GetInt("unlockedLevel"))
            {
                EventSystem.current.firstSelectedGameObject = lvl.lvlButton.gameObject;
            }
            if (lvl.levelID > PlayerPrefs.GetInt("unlockedLevel"))
            {
                lvl.lvlButton.interactable = false;
            }
            else if (lvl.levelID <= PlayerPrefs.GetInt("unlockedLevel"))
            {
                lvl.lvlButton.interactable = true;
            }

        }
    }

}
