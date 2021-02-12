using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Espinho : MonoBehaviour {

    public Health h;

	// Use this for initialization
	void Start () {

       

	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            h.health = -2;
        }
    }
}
