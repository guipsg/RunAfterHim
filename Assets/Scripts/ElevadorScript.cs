using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElevadorScript : MonoBehaviour {
    private Management mg;
    private PontosScript pontosScript;
    [SerializeField] private PlayerMovementPrototype player;
    [SerializeField] private string nextLevel;
    [SerializeField] private int levelID;

    void Start()
    {
        mg = GameObject.FindGameObjectWithTag("Manager").GetComponent<Management>();
        pontosScript = FindObjectOfType<PontosScript>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")){
            player.canMove = false;
            player.Flip();
            player.rb.velocity = new Vector2(0f, 0f);
            player.velocity = 0;
            StartCoroutine(ChangeLevel());
            mg.checkPoint = mg.transform.position;
            PlayerPrefsSystem.SaveLvlPontuation(levelID,pontosScript.points);
            PlayerPrefsSystem.UnlockLevel(levelID + 1);
        }
    }

    IEnumerator ChangeLevel(){
        yield return new WaitForSeconds(.3f);
        float fadeTime = GameObject.Find("Fade").GetComponent<FadeScript>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(nextLevel);
    }
}
