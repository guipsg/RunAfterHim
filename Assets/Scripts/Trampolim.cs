using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour {

    [SerializeField]private float jumpHeight = 300f;
    [SerializeField]private Animator an;
    [SerializeField] private AudioClip audio;
    void OnTriggerStay2D(Collider2D c)
    {

        if (c.gameObject.CompareTag("Player"))

        {
            an.SetBool("Activated", true);
            c.gameObject.GetComponent<PlayerMovementPrototype>().Jump(jumpHeight,audio);

        }

    }
}
