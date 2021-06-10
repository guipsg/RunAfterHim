using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {

    [SerializeField] private float jumpHeight = 300f;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject deathParticle;

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerMovementPrototype>().Jump(jumpHeight,null);
            Destroy(parent, 0.1f);
            Instantiate(deathParticle, transform.position, transform.rotation);
        }


    }

}
