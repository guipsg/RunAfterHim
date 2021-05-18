using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour {

    [SerializeField] private float jumpHeight = 800f;

    void OnCollisionEnter2D(Collision2D c)
    {

        if (c.gameObject.CompareTag("Player"))

        {
            c.gameObject.GetComponent<PlayerMovementPrototype>().Jump(jumpHeight);
        }

    }
}
