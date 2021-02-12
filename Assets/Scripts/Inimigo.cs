using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {

    public int healthEnemy = 2;
    public GameObject parent;
	public GameObject deathParticle;
    void Update()
    {
        if (healthEnemy <= 0)
        {
            Destroy(parent);
			Instantiate (deathParticle, transform.position, transform.rotation);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            healthEnemy -= 2;
        }
        if (col.gameObject.CompareTag("Ball"))
        {
            healthEnemy -= 1;
        }

    }

}
