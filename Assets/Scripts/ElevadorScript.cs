using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElevadorScript : MonoBehaviour {

    [SerializeField] private PlayerMovementPrototype player;
    [SerializeField] private string nextLevel;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")){
<<<<<<< HEAD
            player.canMove = false;
            player.Flip();
            player.rb.velocity = new Vector2(0f, 0f);
            player.velocity = 0;
            mg.menuScript.ChangeScene(nextLevel);
            mg.checkPoint = mg.transform.position;
=======
                player.canMove = false;
                player.Flip();
                player.rb.velocity = new Vector2(0f, 0f);
                player.velocity = 0;
                StartCoroutine(ChangeLevel());
>>>>>>> parent of d149527 (Save System + Cutscenes + Level Selector)
        }
    }

}
