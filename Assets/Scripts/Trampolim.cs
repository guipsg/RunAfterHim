using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour {

    public Rigidbody2D rb;
    public float jumpforce = 300f;
    public Animator an;
    void OnTriggerStay2D(Collider2D c)
    {

        if (c.gameObject.CompareTag("Player"))

        {
            an.SetBool("Activated", true);
            rb.AddForce(Vector2.up * jumpforce);

        }

    }
}
