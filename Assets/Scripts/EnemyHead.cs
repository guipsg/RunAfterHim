using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour {

    public Rigidbody2D rb;
    public float jumpHeight = 800f;

    void OnCollisionEnter2D(Collision2D c)
    {

        if (c.gameObject.CompareTag("Player"))

        {

            rb.AddForce(Vector2.up * jumpHeight);

        }

    }
}
