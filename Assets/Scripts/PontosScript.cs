using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontosScript : MonoBehaviour {

    [SerializeField] private int _points;
    [SerializeField] private Image[] starsImage;
    [SerializeField] private Animator starsHolderAnimator;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private Button levelCompleteSelectButton, gameOverSelectButton;
    [SerializeField] private Image[] completeStarsImage;
    [SerializeField] private bool[] completeStarsBools;
    [SerializeField] private float completeStarsTimeOffset = 1f;
    private void Start()
    {
        levelCompletePanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }
    public int points
    {
        get { return _points; }
        set { _points = value; }
    }
    [SerializeField] private Text pointsText;
    private void Update()
    {
        pointsText.text = (""+points);
    }

    public void UnlockStar(int star)
    {
        starsImage[star].color = Color.white;
        completeStarsBools[star] = true;
        starsHolderAnimator.SetTrigger("Unlock");
    }

    public void ShowLevelComplete()
    {
        levelCompletePanel.SetActive(true);
        
        StartCoroutine(StarsAnimations());
    }

    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
        gameOverSelectButton.Select();
    }

    IEnumerator StarsAnimations()
    {
        yield return new WaitForSeconds(completeStarsTimeOffset);
        if (completeStarsBools[0] == true)
        {
            completeStarsImage[0].gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(completeStarsTimeOffset);
        if (completeStarsBools[1] == true)
        {
            completeStarsImage[1].gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(completeStarsTimeOffset);
        if (completeStarsBools[2] == true)
        {
            completeStarsImage[2].gameObject.SetActive(true);
        }
        levelCompleteSelectButton.Select();
    }
}
