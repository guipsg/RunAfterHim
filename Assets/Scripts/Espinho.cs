using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Espinho : MonoBehaviour {

    [SerializeField] private Health h;
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            h.health = -2;
        }
    }
}
